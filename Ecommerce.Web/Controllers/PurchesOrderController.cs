using System.Linq;
using Ecommerce.Library.Models;
using Ecommerce.Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Web.Controllers
{
    public class PurchesOrderController:Controller
    {
        UnityOfWork _unityOfWork;
        public PurchesOrderController()
        {
            _unityOfWork = new UnityOfWork();
        }

        [HttpGet]
        public IActionResult Create()
        {
            var products = _unityOfWork.ProductRepository.GetAll();

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