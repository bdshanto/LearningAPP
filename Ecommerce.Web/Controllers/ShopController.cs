 
using Ecommerce.BLL.Abstraction.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class ShopController : Controller
    {
        private IShopManager _shopManager;

        public ShopController(IShopManager shopManager)
        {
            _shopManager = shopManager;
        }
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var shops = _shopManager.GetAll();
            return View(shops);
        }
    }
}