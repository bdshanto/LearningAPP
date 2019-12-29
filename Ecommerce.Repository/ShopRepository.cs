using System.Collections.Generic;
using System.Linq;
using Ecommerce.DatabaseContext.DatabaseContext;
using Ecommerce.Models.Contracts;
using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ShopRepository
    {

        private EcommerceDatabaseContext _db; 
        public ShopRepository(EcommerceDatabaseContext db)
        {

            _db = db;
        } 
        public void Add(Shop entity)
        {
            _db.Shops.Add(entity);
        } 

        public void Update(Shop entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }


        public void Remove(Shop entity)
        {
            if (entity is IDeleteable)
            {
                IDeleteable item = (IDeleteable)entity;
                item.IsDeleted = true;
                Update(entity);
            }
            else
            {
                _db.Shops.Remove(entity);
            }
        }

        public Shop GetById(int id)
        {
            return _db.Shops.Find(id);
        }

        public List<Shop> GetAll()
        {
            return _db.Shops.Include(c => c.Products).ToList();
        }

        //Explicit Loading
        public void LoadProduct(Shop shop)
        {
            _db.Entry(shop)
                //multiple object one to many
                .Collection(c => c.Products)
                //single object one to one
                //.refference(c => c.Products)
                .Load();
        }
    }


}