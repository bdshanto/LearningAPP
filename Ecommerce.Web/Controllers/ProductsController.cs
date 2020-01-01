using System.Collections.Generic;
using System.Net.Mime;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ViewModels.Web.Product;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Web.Controllers
{
    public class ProductsController : Controller
    {     //Create
        private IProductManager _productManager;

        private IShopManager _shopManager;
        /*Contractors*/
        public ProductsController(IProductManager productManager, IShopManager shopManager)
        {
            _productManager = productManager;
            _shopManager = shopManager;
        }

        /*products/index*/
        public IActionResult Index()
        {
            var products = _productManager.GetAll();
            return View(products);
        }
        //products create


        [HttpGet]
        public IActionResult Create()
        {
            var shops = _shopManager.GetAll();

            var items = shops.Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
            }).ToList();

            ViewBag.Shops = items;
            return View();
        }

        [HttpPost]
        public IActionResult Create(ProductCreateVm model)
        {


            if (ModelState.IsValid)
            {
                
                bool isAdded = _productManager.Add(product);
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
            var shops = _shopManager.GetAll();

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
            var products = _productManager.GetShopId(shopId);
            return Json(products);
            
        }
        public IActionResult GetProductById(int productId)
        {
            var product = _shopManager
                .GetById(productId);
            return Json(product);
        }
    }
}