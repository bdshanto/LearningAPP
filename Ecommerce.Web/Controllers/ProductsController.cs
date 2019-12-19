using System.Collections.Generic;
using System.Net.Mime;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Ecommerce.Library.Models;
using Ecommerce.Library.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Web.Controllers
{
    public class ProductsController : Controller
    {     //Create
        private readonly UnityOfWork _unityOfWork;
        /*Contractors*/
        public ProductsController()
        {
            _unityOfWork = new UnityOfWork();
        }

        /*products/index*/
        public IActionResult Index()
        {
            var products = _unityOfWork.ProductRepository.GetAll();
            return View(products);
        }
        //products create


        [HttpGet]
        public IActionResult Create()
        {
            var shops = _unityOfWork.ShopRepository.GetAll();

            var items = shops.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            }).ToList();

            ViewBag.Shops = items;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _unityOfWork.ProductRepository.Add(product);
                bool isAdded = _unityOfWork.SaveChange();
                if (isAdded)
                {
                    return View("Index");
                }
            }
            return View();
        }
        /*dropdown load */
        public IActionResult ProductView()
        {
            var shops = _unityOfWork.ShopRepository.GetAll();

            var items = shops.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            }).ToList();

            ViewBag.Shops = items;
            return View();
        }

        public IActionResult GetProductByShopId(int shopId)
        {
            var products = _unityOfWork.ProductRepository.GetShopId(shopId);
            return Json(products);
            
        }
        public IActionResult GetProductById(int productId)
        {
            var product = _unityOfWork
                .ProductRepository
                .GetById(productId);
            return Json(product);
        }
    }
}