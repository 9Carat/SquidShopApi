
using Microsoft.AspNetCore.Identity;
using SquidShopApi.Data;
using SquidShopApi.Models;
using SquidShopApi.Repository.IRepository;
using SquidShopApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace SquidShopApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddControllers().AddNewtonsoftJson();
            builder.Services.AddScoped<IRepository<Product>, GenericRepository<Product>>();
            builder.Services.AddScoped<IRepository<Category>, GenericRepository<Category>>();
            builder.Services.AddScoped<IRepository<User>, GenericRepository<User>>();
            builder.Services.AddScoped<IRepository<IdentityUser>, GenericRepository<IdentityUser>>();
            builder.Services.AddScoped<IRepository<Order>, GenericRepository<Order>>();
            builder.Services.AddScoped<IRepository<OrderList>, GenericRepository<OrderList>>();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingConfig));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}