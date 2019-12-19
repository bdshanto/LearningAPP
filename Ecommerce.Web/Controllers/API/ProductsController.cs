using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.Library.Models;
using Ecommerce.Library.Repositories;
using Ecommerce.Library.ViewModels.API.Products;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers.API
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        UnityOfWork _unityOfWork;

        public ProductsController()
        {
            _unityOfWork = new UnityOfWork();
        }


        // GET

        public IEnumerable<ProductVM> Get()
        {

            var products = _unityOfWork
                .ProductRepository
                .GetAll()
                .Select(c => new ProductVM(){
                    Id = c.Id,Name = c.Name,Price = c.Price,Code = c.Code,
                   Shop = new ShopVm
                   {
                       Name = c.Name,
                       Id = c.Id
                   }
                });



            return products.ToList();
        }
    }
}