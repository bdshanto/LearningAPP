using AutoMapper;
using Ecommerce.Models.EntityModels;
using Ecommerce.Models.ViewModels.Web.Product;

namespace Ecommerce.Web.AutoMapperConfig
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<ProductCreateVm, Product>();
            CreateMap<Product, ProductCreateVm>();
        }
    }
}