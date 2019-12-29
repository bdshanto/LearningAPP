using System.Collections.Generic;
using Ecommerce.Models.DTO;
using Ecommerce.Models.EntityModels;

namespace Ecomerce.BLL.Abstraction.Contracts
{
    public interface IProductManager:IManager<Product>
    {
        ICollection<Product> Search(ProductSearchCriteriaDTO dto);
        ICollection<Product> GetShopId(int shopId);

    }
}