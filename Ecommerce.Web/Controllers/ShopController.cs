using Ecommerce.Library.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Web.Controllers
{
    public class ShopController : Controller
    {
        private UnityOfWork _unityOfWork; 
        public ShopController()
        {
            _unityOfWork = new UnityOfWork();
        }
         
        // GET
        [HttpGet]
        public IActionResult Index()
        {
            var shops = _unityOfWork.ShopRepository.GetAll();
            return View(shops);
        }
    }
}