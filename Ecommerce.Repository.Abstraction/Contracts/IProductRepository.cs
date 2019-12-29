using System.Collections.Generic;
using Ecommerce.Models.DTO;
using Ecommerce.Models.EntityModels;

namespace Ecommerce.Repository.Abstraction.Contracts
{
    public interface IProductRepository : IRepository<Product>
    { 
        List<Product> Search(ProductSearchCriteriaDTO dto);
        ICollection<Product> GetShopId(int shopId);
         
    }
}