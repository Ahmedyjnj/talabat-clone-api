﻿using Domain.Contracts;
using Domain.Models.Identity;
using Domain.Models.Orders;
using Domain.Models.Products;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Persistance.Data
{
    public class DbInializer(StoreDBContext context,UserManager<ApplicationUser> userManager,RoleManager<IdentityRole> roleManager,StoreIdentityDbContext identityDbContext ) : IDbInializer
    {
        public async Task IdentityInializeAsync()
        {
            try { 
            if (! roleManager.Roles.Any())
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
                await roleManager.CreateAsync(new IdentityRole("SuperAdmin"));

            }

            if(!userManager.Users.Any())
            {
                var User1 = new ApplicationUser()
                {
                    Email="Ahmed@gmail.com",
                    UserName = "AhmedNasser",
                    DisplayName = "Ahmed Nasser",
                    PhoneNumber = "01112643021",

                };

                var User2 = new ApplicationUser()
                {
                    Email ="Yassmine@gmail.com",
                    UserName = "YassmineNasser",
                    DisplayName = "Yassmine Nasser",
                    PhoneNumber = "01112643022",
                };

                await userManager .CreateAsync(User1,"P@ssw0rd");
                await userManager.CreateAsync(User2, "P@ssw0rd");

                await userManager.AddToRoleAsync(User1, "Admin");

                await userManager.AddToRoleAsync(User2, "SuperAdmin"); 

                // we can add user to multiple roles

                await identityDbContext.SaveChangesAsync(); // this will save the changes in identity db context
            }
            }
            catch(Exception ex)
            {
                throw;
            }




        }

        //we will convert files into objects then make save by context

        //we should begin in insert with table that dont have forign key 




        public async Task InializeAsync()
        {
            if ((await context.Database.GetPendingMigrationsAsync()).Any())
            {
                await context.Database.MigrateAsync();
            }

            try
            {
                if (!context.Set<ProductBrand>().Any())
                {
                    
                    var data = await File.ReadAllTextAsync(@"..\Persistance\Data\Seeds\brands.json");

                    var objects = JsonSerializer.Deserialize<List<ProductBrand>>(data); //دى هتفكك الملف الى قائمة 

                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductBrand>().AddRange(objects); //دى هتضيف العناصر الى الجدول
                        await context.SaveChangesAsync(); //دى هتعمل حفظ للبيانات
                    }


                }


                if (!context.Set<ProductType>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Persistance\Data\Seeds\types.json");

                    var objects = JsonSerializer.Deserialize<List<ProductType>>(data); //دى هتفكك الملف الى قائمة 

                    if (objects is not null && objects.Any())
                    {
                        context.Set<ProductType>().AddRange(objects); //دى هتضيف العناصر الى الجدول
                        await context.SaveChangesAsync(); //دى هتعمل حفظ للبيانات
                    }


                }

                if (!context.Set<Product>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Persistance\Data\Seeds\products.json");

                    var objects = JsonSerializer.Deserialize<List<Product>>(data); //دى هتفكك الملف الى قائمة 

                    if (objects is not null && objects.Any())
                    {
                        //context.Set<Product>().AddRange(objects); //دى هتضيف العناصر الى الجدول
                        //await context.SaveChangesAsync(); //دى هتعمل حفظ للبيانات

                        foreach (var product in objects)
                        {
                            // 1) Add the single product
                            context.Set<Product>().Add(product);

                            // 2) Save immediately
                            await context.SaveChangesAsync();
                        }

                    }


                }




                if (!context.Set<DeliveryMethod>().Any())
                {
                    var data = await File.ReadAllTextAsync(@"..\Persistance\Data\Seeds\delivery.json");

                    var objects = JsonSerializer.Deserialize<List<DeliveryMethod>>(data); //دى هتفكك الملف الى قائمة 

                    if (objects is not null && objects.Any())
                    {
                        //context.Set<Product>().AddRange(objects); //دى هتضيف العناصر الى الجدول
                        //await context.SaveChangesAsync(); //دى هتعمل حفظ للبيانات

                        foreach (var delivery in objects)
                        {
                            // 1) Add the single product
                            context.Set<DeliveryMethod>().Add(delivery);

                            // 2) Save immediately
                            await context.SaveChangesAsync();
                        }

                    }


                }










            }
            catch (Exception ex)
            {
                throw;
            }

          
            

            //this initialize will run automatic
            // we will make in it also appling migrations automatic rather than using update database




        }
    }
}
