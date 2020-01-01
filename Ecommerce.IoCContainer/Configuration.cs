using Ecommerce.BLL;
using Ecommerce.BLL.Abstraction.Contracts;
using Ecommerce.DatabaseContext.DatabaseContext;
using Ecommerce.Models.EntityModels;
using Ecommerce.Repository;
using Ecommerce.Repository.Abstraction.Contracts;
using Ecommerce.Repository.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.IoCContainer
{
    public static class IoCContainer
    {
        public static void Configure(IServiceCollection services)
        {
            //Transient working a single request
            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<ICustomerManager, CustomerManager>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();

            services.AddTransient<IProductManager, ProductManager>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IShopManager, ShopManager>();
            services.AddTransient<IShopRepository, ShopRepository>();

            services.AddTransient<IPurchesOrderManager, PurchesOrderManager>();
            services.AddTransient<IPurchesOrderRepository, PurchesOrderRepository>();

           //DatabaseContext DI
            services.AddTransient<DbContext,EcommerceDatabaseContext>();
           services.AddTransient<EcommerceDatabaseContext>(); 

        }

    }
}
