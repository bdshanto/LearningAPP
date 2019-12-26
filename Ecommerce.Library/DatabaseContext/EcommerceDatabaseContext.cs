using Microsoft.EntityFrameworkCore;
using Ecommerce.Library.Models;
using Microsoft.Extensions.Configuration;

namespace Ecommerce.Library.DatabaseContext
{
    public class EcommerceDatabaseContext : DbContext
    {
        private IConfiguration _configuration;

        public EcommerceDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;

        }


        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PurchesOrder> PurchesOrders { get; set; }
        public DbSet<PurchesOrderItem> PurchesOrderItems { get; set; }



        //Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //connection string builder 
            var connString = _configuration.GetConnectionString("AppConnectionString");
            optionsBuilder.UseSqlServer(connString);
            /*Lazy loading*/
            /*optionsBuilder.UseLazyLoadingProxies();*/

            base.OnConfiguring(optionsBuilder);
        }
        //Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Customer primaryKey*/
            modelBuilder.Entity<Customer>().HasKey(c => c.Id);
            /*Shop primary key*/
            modelBuilder.Entity<Shop>().HasKey(c => c.Id);
            /*Product primary key*/
            modelBuilder.Entity<Product>().HasKey(c => c.Id);
            /*One to many relationship*/
            modelBuilder.Entity<Product>()
                .HasOne<Shop>(c => c.Shop)
                .WithMany(d => d.Products)
                .HasForeignKey(x => x.ShopId);
            base.OnModelCreating(modelBuilder);

            /*query filter*/
            modelBuilder.Entity<Product>().HasQueryFilter(c => c.IsDeleted == false);
        }
    }
}
