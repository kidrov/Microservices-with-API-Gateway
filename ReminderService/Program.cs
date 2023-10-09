using DAL;
using Microsoft.EntityFrameworkCore;
using Service;

namespace ReminderService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<IReminderRepository, ReminderRepository>();
            builder.Services.AddScoped<IReminderService, ReminderServ>();

            builder.Services.AddDbContext<KeepDbContext>(op =>
            {
                op.UseSqlServer(builder.Configuration["ConnectionStrings:MyConnectionString"]);
            });
            builder.Services.AddConsulConfig(builder.Configuration); 
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