using System.Collections.Generic;
using Ecommerce.BLL.Abstraction.Base;
using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.Models.DTO;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repository.Abstraction.Contracts;

namespace Ecommerce.BLL
{
    public class ProductManager : Manager<Product>, IProductManager
    {
        private IProductRepository _productRepository;

        public ProductManager(IProductRepository repository):base(repository)
        {
            _productRepository = repository;
        }   

        public ICollection<Product> Search(ProductSearchCriteriaDTO dto)
        {
           return _productRepository.Search(dto);
        }
        public ICollection<Product> GetShopId(int shopId)
        {
            return _productRepository.GetShopId(shopId);
        }

    }
}