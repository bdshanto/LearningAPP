using System.Collections.Generic;
using System.Linq;
using Ecommerce.DatabaseContext.DatabaseContext;
using Ecommerce.Models.Contracts;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repository.Abstraction.Base;
using Ecommerce.Repository.Abstraction.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository
{
    public class ShopRepository:Repository<Shop>,IShopRepository
    {

        private EcommerceDatabaseContext _db; 
        public ShopRepository(DbContext db):base(db)
        {

            _db = db as EcommerceDatabaseContext;
        } 
     

        public override void Update(Shop entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
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