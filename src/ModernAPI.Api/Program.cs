using Microsoft.EntityFrameworkCore;
using ModernAPI.DataAccess.Context;
using System.Diagnostics;

namespace ModernAPI.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);



            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<UserContext>(options =>
                 options.UseMySql(
                     builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(9, 3, 0))
                 )
            );

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReact", policy =>
                {
                    policy.WithOrigins("http://localhost:5173")
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<UserContext>();
                if (!context.Database.CanConnect())
                {
                    Debug.WriteLine("A connection to the database was not able to be established.");
                    Environment.Exit(1);
                }
            }

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //app.UseAuthorization();

            app.UseCors("AllowReact");
            app.MapControllers();

            app.Run();
        }
    }
}
