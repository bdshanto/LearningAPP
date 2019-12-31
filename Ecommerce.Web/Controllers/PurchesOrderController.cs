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
        public PurchesOrderController( IPurchesOrderManager purchesOrderManager)
        {
            _purchesOrderManager = purchesOrderManager;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var products = _purchesOrderManager.GetAll();

            var items = products.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
            ViewBag.products = items;
            return View();
        }
        [HttpPost]
        public IActionResult Create(PurchesOrder  model)
        {

            if (ModelState.IsValid)
            {
                _unityOfWork.PurchesOrderRepository.Add(model);
               _unityOfWork.SaveChange();
            }
                
           
            var products = _unityOfWork.ProductRepository.GetAll();
            var items = products.Select(x => new SelectListItem()
            {
                Text = x.Name,
                Value = x.Id.ToString()

            });
            ViewBag.products = items;  
            return View();
        }
        
    }
}