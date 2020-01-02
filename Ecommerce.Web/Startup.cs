using AutoMapper;
using Ecommerce.DatabaseContext.DatabaseContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
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
        {  services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            
            //Create a connectionString
            services
                .AddDbContext<EcommerceDatabaseContext>(options => options
                    .UseSqlServer(Configuration
                        .GetConnectionString("AppConnectionString")));

            //services.AddJsonOptions(options => options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore);
            //AutoMapper
            services.AddAutoMapper(typeof(Startup));
            /*Razor to edit in debugger mode*/
            services.AddRazorPages().AddRazorRuntimeCompilation();

            IoCContainer.IoCContainer.Configure(services);

            services.AddAuthentication(option =>
                {
                    option.DefaultScheme = "Cookies";
                    option.DefaultChallengeScheme = "oidc";
                })
                .AddCookie("Cookies")
                .AddOpenIdConnect("oidc", option =>
                {
                    
                    option.Authority = "https://localhost:44387/";
                    option.RequireHttpsMetadata = false;

                    option.ClientId = "web_client";
                    option.ClientSecret = "secret";
                    option.ResponseType = "code id_token";
                    
                    option.SignInScheme = "Cookies";
                    option.SaveTokens = true;
                    option.GetClaimsFromUserInfoEndpoint = true;

                });


            //Transient working a single request 
            services.AddMvc() 
                //XML Output
                 .AddMvcOptions(option =>
                {
                    option.OutputFormatters.Add(new XmlSerializerOutputFormatter());

                }) 
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
            
            app.UseRouting();
            app.UseCookiePolicy(); 
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                /*
                 endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Shop}/{action=Index}/{id?}");
                */

                endpoints.MapControllerRoute(
                     "default",
                     "{controller=Shop}/{action=Index}/{id?}");
            });
        }
    }
}
