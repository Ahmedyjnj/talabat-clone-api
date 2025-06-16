
using Abstraction;
using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Persistance.Data;
using Persistance.Repositories;
using Services;
using System.Threading.Tasks;

namespace E_CommereceWep
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region DI Container Services
            // Add services to the container.

            builder.Services.AddControllers(); // in mvc use addcontrollersWithViews
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            //to anderstand that we need to make mapper in assemply of a service we will make 
            // File assemplyreference  class and pass to it

            //that will tell a automapper to scan the assembly for all profiles in assemply of
            //assemblyreference class
            builder.Services.AddAutoMapper(typeof(AssemblyReferences).Assembly);

            //// we have aproblem ecommerce wep dont see persistance

            builder.Services.AddDbContext<StoreDBContext>(options =>
            {
                var ConnectionString=builder.Configuration.GetConnectionString("DefaultConnection");

                options.UseSqlServer(ConnectionString);

            });

            builder.Services.AddScoped<IDbInializer,DbInializer>(); 
            //«·„‘ﬂ·… „Õœ‘ ÂÌÿ·»Â« ›Â‰ Õ«Ì· 
            
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(); 

            builder.Services.AddScoped<IServiceManager, ServicesManager>();

            #endregion


            var app = builder.Build();


            await InitializeDbAsync(app);

            #region MiddleWares -configure pipelines

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseStaticFiles();

            app.MapControllers();

            // in this pipelines we dont have routing or map routing 
            // because we are using attribute routing in controller in api






            #endregion

            app.Run();
        }


        public static async Task InitializeDbAsync(WebApplication app)
        {
            using var scope = app.Services.CreateScope(); //using to automatic deleted by clr dispose created scope by di

            var dbInializer = scope.ServiceProvider.GetRequiredService<IDbInializer>();
            await  dbInializer.InializeAsync();

        }
    }
}




//here we dont have models because we will work on specific structure
// package swachbuckle is used to generate the swagger
// in launch settings we have used a iis express in mvc because it out the error in views
// we will use kestral
//E_CommereceWep.http this is new in .net8 for test as post man or swagger documentation


// WeatherForecastController : ControllerBase this is best than controller because it is light weight not have views











