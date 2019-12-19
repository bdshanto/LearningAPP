using System;
using System.Collections.Generic;
using System.Linq;
using Ecommerce.Library.Models;
using Ecommerce.Library.Repositories;
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

        public IEnumerable<dynamic> Get()
        {

            var products = _unityOfWork
                .ProductRepository
                .GetAll()
                .Select(c => new
                {
                    c.Id,
                    c.Name,
                    c.Price,
                    Shop = new Shop
                    {
                        Id = c.Id,
                        Name = c.Name,
                    }
                });



            return products.ToList();
        }
    }
}