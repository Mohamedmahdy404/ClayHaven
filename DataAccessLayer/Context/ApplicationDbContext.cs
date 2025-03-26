using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context
{
   public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option):base(option)
        {
        }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<OrderProduct> OrderProducts { set; get; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly
            );
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(), // Unique ID for the role
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(), // Unique ID for the role
                    Name = "Buyer",
                    NormalizedName = "BUYER"
                },
                new IdentityRole
                {
                    Id = Guid.NewGuid().ToString(), // Unique ID for the role
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );



        }
    }
}
