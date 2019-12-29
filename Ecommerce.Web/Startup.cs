using Ecommerce.DatabaseContext.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
 
namespace Ecommerce.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime.
        // Use this method to add services to the container.
        // Dependency Injection mapping
        public void ConfigureServices(IServiceCollection services)
        { //Create a connectionString
            services
                .AddDbContext<EcommerceDatabaseContext>(options =>options
                    .UseSqlServer(Configuration
                        .GetConnectionString("AppConnectionString")));


            services.AddControllersWithViews();
            /*Razor to edit in debugger mode*/
            services.AddRazorPages().AddRazorRuntimeCompilation();

            IoCContainer.IoCContainer.Configure(services);
            //Transient working a single request 
            services.AddMvc()
                
                //XML Output
                /*.AddMvcOptions(option =>
                {
                    option.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                })*/
               // .AddJsonOptions(options => { options.JsonSerializerOptions.IgnoreNullValues = true; } )
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime.
        // Use this method to configure the HTTP request pipeline.
        //Middleware services
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            //wwwroot 
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseRouting();

            app.UseAuthorization(

                );

            app.UseEndpoints(endpoints =>
            {
                /*
                 endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=Index}/{id?}");
                */

                endpoints.MapControllerRoute(
                     "default",
                     "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
