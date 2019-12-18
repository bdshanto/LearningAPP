using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Ecommerce.Library.Models;

namespace Ecommerce.Library.DatabaseContext
{
    public class EcommerceDatabaseContext : DbContext
    {
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<PurchesOrder> PurchesOrders { get; set; }
        public DbSet<PurchesOrderItem> PurchesOrderItems { get; set; }



        //Connection String
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(local); Database=Ecommerce_DB; Integrated Security=True");
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
