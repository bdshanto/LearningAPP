using System.Collections.Generic;
using System.Linq;
using Ecommerce.Library.Contracts;
using Ecommerce.Library.DatabaseContext;
using Ecommerce.Library.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Library.Repositories
{
    public class ProductRepository
    {
        private EcommerceDatabaseContext _db;
        public ProductRepository(EcommerceDatabaseContext db)
        {
            _db = db;
        }
        public void Add(Product entity)
        {
            _db.Products.Add(entity);
        }


        public void Update(Product entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
        }


        public void Remove(Product entity)
        {
            // ReSharper disable once MergeCastWithTypeCheck
            if (entity is IDeleteable)
            {
                IDeleteable item = (IDeleteable)entity;
                item.IsDeleted = true;
                Update(entity);
            }
            else
            {
                _db.Products.Remove(entity);
            }
        }

        public Product GetById(int id)
        {
            return _db.Products.Find(id);
        }


        public List<Product> GetAll()
        {
            /*Eager Loading*/
                        return _db.Products.Include(c=>c.Shop).ToList();

//            return _db.Products.ToList();
        }


        public ICollection<Product> GetShopId(int shopId)
        {
            return _db.Products.Where(x => x.ShopId==shopId).ToList();
        }
    }
}