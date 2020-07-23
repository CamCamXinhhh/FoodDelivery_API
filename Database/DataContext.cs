using FoodDelivery.Database.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDelivery.Database
{
    public class DataContext : IdentityDbContext<User>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Favourite> Favourites { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //Product - Category
            builder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products);

            //Favourite - Product
            builder.Entity<Favourite>()
                .HasOne(f => f.Product)
                .WithMany(p => p.Favourites)
                .HasForeignKey(f => f.ProductId);

            //Favourite - User
            builder.Entity<Favourite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favourites)
                .HasForeignKey(f => f.UserId);
        }
    }
}
