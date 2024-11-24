using Domins.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domins
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<UserUpload> UserUploads { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<CustomProduct> CustomProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure one-to-one relationship between Category and Product
            modelBuilder.Entity<Category>()
                .HasOne(c => c.Product)  // Category has one Product
                .WithOne(p => p.Categories)  // Product has one Category
                .HasForeignKey<Product>(p => p.CategoryId); // Specify foreign key property
        }


    }
}
