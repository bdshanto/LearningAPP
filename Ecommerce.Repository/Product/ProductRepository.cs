using System.Collections.Generic;
using System.Linq;
using Ecommerce.DatabaseContext.DatabaseContext;
using Ecommerce.Models.Contracts;
using Ecommerce.Models.DTO;
using Ecommerce.Repository.Abstraction.Base;
using Ecommerce.Repository.Abstraction.Contracts; 
using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Product
{
    public class ProductRepository : Repository<Models.EntityModels.Product>,IProductRepository
    {
        // 
        private EcommerceDatabaseContext _db;
     
        public ProductRepository(DbContext db):base(db)
        {
            _db = (EcommerceDatabaseContext)db;
        } 

        public override void Remove(Models.EntityModels.Product entity)
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

        public override Models.EntityModels.Product GetById(int id)
        {
            return _db.Products.Include(c => c.Shop).FirstOrDefault(c => c.Id == id);
        }


        public override ICollection<Models.EntityModels.Product> GetAll()
        {
            /*Eager Loading*/
            return _db.Products.Include(c => c.Shop).ToList();

            //            return _db.Products.ToList();
        }

        public List<Models.EntityModels.Product> Search(ProductSearchCriteriaDTO dto)
        {
            /////
            ////difference between 
            //IQueryable
            //AsEnumerable
            /////
            var products = _db.Products.Include(c => c.Shop).AsQueryable();
            if (!string.IsNullOrEmpty(dto.Name))
            {
                products = products.Where(c => c.Name.ToLower().Contains(dto.Name.ToLower()));
            }

            if (Equals(!string.IsNullOrEmpty(dto.Code)))
            {
                products = products.Where(c => c.Code.ToLower().Contains(c.Code.ToLower()));
            }

            if (dto.FromSalesPrice > 0)
            {
                products = products.Where(c => c.Price > dto.FromSalesPrice);
            }

            if (dto.ToSalesPrice > 0)
            {
                products = products.Where(c => c.Price <= dto.ToSalesPrice);
            }

            if (dto.ShopId != null && dto.ShopId > 0)
            {
                products = products.Where(c => c.ShopId == dto.ShopId);
            }
            return products.ToList();
        }


        public ICollection<Models.EntityModels.Product> GetShopId(int shopId)
        {
            return _db.Products.Where(x => x.ShopId == shopId).ToList();
        }
    }
}