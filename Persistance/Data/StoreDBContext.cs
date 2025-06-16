using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Data
{
    public class StoreDBContext(DbContextOptions options) :DbContext(options)
    {

        //public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        //this is old away above is new 


        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> Types{ get; set; }

        public DbSet<ProductBrand> Brands { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(typeof(AssemblyReference).Assembly);
        }


    }
}
