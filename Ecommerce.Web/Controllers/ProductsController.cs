using System.Linq;
using AutoMapper;
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

        private IMapper _mapper;
        /*Contractors*/
        public ProductsController(IProductManager productManager, IShopManager shopManager, IMapper mapper)
        {
            _productManager = productManager;
            _shopManager = shopManager;
            _mapper = mapper;
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
            var product=_mapper.Map<Product>(model);


            if (ModelState.IsValid)
            {
                
                bool isAdded = _productManager.Add(product);
                if (isAdded)
                {
                    return RedirectToAction("Index");
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