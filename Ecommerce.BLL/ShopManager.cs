using Ecommerce.BLL.Abstraction.Base;
using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repository.Abstraction.Contracts;

namespace Ecommerce.BLL
{
    public class ShopManager:Manager<Shop>,IShopManager
    {
        private IShopRepository _shopRepository;

        public ShopManager(IShopRepository shopRepository):base(shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public void LoadProduct(Shop shop)
        {
          _shopRepository.LoadProduct(shop);
        }
    }
}