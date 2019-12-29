﻿using System.Collections.Generic;
using System.Linq;
using Ecommerce.Library.Contracts;
using Ecommerce.Library.DatabaseContext;
using Ecommerce.Library.DTO;
using Ecommerce.Library.Models;
using Ecommerce.Repository.Base;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Library.Repositories
{
    public class ProductRepository : Repository<Product>
    {
        // 
        private EcommerceDatabaseContext _db;  
        public ProductRepository(DbContext db):base(db)
        {
            _db = (EcommerceDatabaseContext)db;
        }
       
         

        public override void Remove(Product entity)
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

        public override Product GetById(int id)
        {
            return _db.Products.Include(c => c.Shop).FirstOrDefault(c => c.Id == id);
        }


        public override ICollection<Product> GetAll()
        {
            /*Eager Loading*/
            return _db.Products.Include(c => c.Shop).ToList();

            //            return _db.Products.ToList();
        }

        public ICollection<Product> Search(ProductSearchCriteriaDTO dto)
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


        public ICollection<Product> GetShopId(int shopId)
        {
            return _db.Products.Where(x => x.ShopId == shopId).ToList();
        }
    }
}