using Ecommerce.Models.EntityModels;

namespace Ecommerce.Repository.Abstraction.Contracts
{
    public interface IShopRepository:IRepository<Shop>
    {
        void LoadProduct(Shop shop);
    }
}