using System.Collections.Generic;
using System.Linq;
using Ecommerce.Library.DTO;
using Ecommerce.Library.Models;
using Ecommerce.Library.Repositories;
using Ecommerce.Library.ViewModels.API.Products;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers.API
{
    [Route("api/products")]
    public class ProductsController : ControllerBase
    {
        IUnityOfWork _unityOfWork;

        public ProductsController(IUnityOfWork unityOfWork)
        {
            _unityOfWork = unityOfWork;
        }


        // GET all

        public IEnumerable<ProductVM> Get(ProductSearchCriteriaDTO model)
        {

            var products = _unityOfWork
                .ProductRepository
                .Search(model)
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
        //get by id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var products = _unityOfWork.ProductRepository.GetById(id);

            if (products==null)
            {
                return NotFound();
            }
            var product = new ProductVM()
            {
                Id = products.Id,
                Name = products.Name,
                Code = products.Code,
                Price = products.Price,
                Shop = new ShopVm()
                {
                    Id = products.Shop.Id,
                    Name = products.Shop?.Name
                }

            };
            return Ok(product);
        }
        //add a file 
        [HttpPost]
        public IActionResult Post([FromBody]Product model)
        {
            if (ModelState.IsValid)
            {
                _unityOfWork.ProductRepository.Add(model);
                bool idSuccess = _unityOfWork.SaveChange();
                if (idSuccess)
                {
                    return Ok(model);

                }

              
            }
            return BadRequest(ModelState);
        }
        //update data
        [HttpPut]
        public IActionResult Put([FromQuery] int id, [FromBody] Product product)
        {
            var existProduct = _unityOfWork.ProductRepository.GetById(id); 
            if (existProduct==null)
            {
                return BadRequest("Product not found");
            }

            existProduct.Id = product.Id;
            existProduct.Price = product.Price;
            existProduct.Shop.Id = product.Shop.Id;
            existProduct.Shop.Name = product.Shop.Name;
            existProduct.WarehouseLocation=product.WarehouseLocation;



            _unityOfWork.ProductRepository.Update(existProduct);
            bool isUpdated = _unityOfWork.SaveChange();
            if (isUpdated)
            {
                return Ok();
            }

            return BadRequest("bad request");
        }
        [HttpDelete("{id}")]
        public IActionResult Delete([FromQuery]int id )
        {
            var product = _unityOfWork.ProductRepository.GetById(id);
            if (product==null)
            {
                return NotFound();
            }
            _unityOfWork.ProductRepository.Remove(product);
            bool idDeleted = _unityOfWork.SaveChange();
            if (idDeleted)
            {
                return Ok();
            }

            return BadRequest();
        }
        
    }
}