using Domain.Models.Products;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Data
{
    public class StoreDBContext(DbContextOptions<StoreDBContext> options) :DbContext(options)
    {

        //public StoreDBContext(DbContextOptions<StoreDBContext> options) : base(options)
        //this is old away above is new 


        public DbSet<Product> Products { get; set; }

        public DbSet<ProductType> Types{ get; set; }

        public DbSet<ProductBrand> Brands { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
            // the problem he cant read in migration after configuration we need to change assemply
            //we should use get excuting assemply

        }


    }
}
