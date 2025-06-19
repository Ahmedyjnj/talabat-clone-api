using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Data
{
    public class StoreIdentityDbContext(DbContextOptions<StoreIdentityDbContext> options): IdentityDbContext<ApplicationUser>(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
         
            base.OnModelCreating(builder);

            //here we will modify the table of identity that generates as default

            //we will begin with names and what table we need

            builder.Entity<Address>().ToTable("Addresses");

            builder.Entity<ApplicationUser>().ToTable("Users");

            builder.Entity<IdentityRole>().ToTable("Roles");

            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");

            ////////////////////////////////////////////
            // /Ignoration 

            builder.Ignore<IdentityUserClaim<string>>(); 
            builder.Ignore<IdentityUserLogin<string>>();
            builder.Ignore<IdentityUserToken<string>>();
            builder.Ignore<IdentityRoleClaim<string>>();


        }



    }
}
