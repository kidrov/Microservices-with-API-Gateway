using DAL;
using Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
namespace CategoryService

{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add configuration
            builder.Configuration.AddJsonFile("appsettings.json"); // Load configuration from appsettings.json

            // Configure MongoDB
            var connectionString = builder.Configuration.GetConnectionString("MongoDBConnection");
            var databaseName = builder.Configuration.GetSection("MongoDBSettings")["DatabaseName"];
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            builder.Services.AddSingleton<IMongoDatabase>(database);
            builder.Services.AddSingleton<IMongoClient>(client);
            builder.Services.AddConsulConfig(builder.Configuration);
            
            // Add services to the container.
            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryServ>();

            builder.Services.AddControllers();

          
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();
            app.UseConsul(builder.Configuration);
            app.Run();
        }
    }
}