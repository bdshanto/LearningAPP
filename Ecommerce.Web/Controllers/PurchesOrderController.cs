using System.Collections.Generic;
using System.Linq;
using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.Models.EntityModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Web.Controllers
{
    public class PurchesOrderController:Controller
    {
        private IPurchesOrderManager _purchesOrderManager;
        private IProductManager _productManager;

        public PurchesOrderController( IPurchesOrderManager purchesOrderManager, IProductManager productManager)
        {
            _purchesOrderManager = purchesOrderManager;
            _productManager = productManager;
        }


        [HttpGet]
        public IActionResult Create()
        {
            var products = _productManager.GetAll();

                
            ViewBag.products =SelectProductListItems();
            return View();
        }
        [HttpPost]
        public IActionResult Create(PurchesOrder  model)
        {

            if (ModelState.IsValid)
            {
                _purchesOrderManager.Add(model);
               
            }


            var items = SelectProductListItems();
            ViewBag.products = items;  
            return View();
        }

        private IEnumerable<SelectListItem> SelectProductListItems()
        {
            var products = _productManager.GetAll();

            var items = products.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()
            });
            return items;
        }
    }
}