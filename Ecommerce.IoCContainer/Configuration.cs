using Ecomerce.BLL.Abstraction.Contracts;
using Ecommerce.BLL;
using Ecommerce.DatabaseContext.DatabaseContext;
using Ecommerce.Models.EntityModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.IoCContainer
{
    public static class IoCContainer
    {  
        public static void Configure(IServiceCollection services)
        {  
            //Transient working a single request
            services.AddTransient<IProductManager,ProductManager>();
            services.AddTransient<DbContext,EcommerceDatabaseContext>();
           services.AddTransient<EcommerceDatabaseContext>(); 
        }
        
    }
}