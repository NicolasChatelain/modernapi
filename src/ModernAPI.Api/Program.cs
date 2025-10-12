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

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<UserContext>(options =>
                 options.UseMySql(
                     builder.Configuration.GetConnectionString("DefaultConnection"),
                     new MySqlServerVersion(new Version(9, 3, 0))
                 )
             );

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


            app.MapControllers();

            app.Run();
        }
    }
}
