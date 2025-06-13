
using MeineRestApi.Context;
using Microsoft.EntityFrameworkCore;

namespace MeineRestApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();

            // EF Core DbContext ayarý - anahtar uyumlu
            builder.Services.AddDbContext<BuchContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("BuchDatenbank")));

            // Swagger/OpenAPI ayarlarý
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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

