using Ecommerce.Models.EntityModels;

namespace Ecommerce.BLL.Abstraction.Contracts
{
    public interface IShopManager:IManager<Shop>
    {
        void LoadProduct(Shop shop);

    }
}