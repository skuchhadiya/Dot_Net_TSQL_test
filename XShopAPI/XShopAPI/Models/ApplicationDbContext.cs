using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;

using System.Text;
using XShopData.Models;

namespace XShopAPI.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<CategoryDetail> CategoryDetails { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ProductDetail>()
                .ToTable("productDetail", "product")
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<CategoryDetail>()
                 .ToTable("categoryDetail", "category")
                 .Property(x => x.Id)
                 .ValueGeneratedOnAdd();

        }
    }
   }
