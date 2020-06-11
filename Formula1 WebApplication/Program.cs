using Formula1_WebApplication.DAL;
using Formula1_WebApplication.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;

namespace Formula1_WebApplication
{
    public class Program
    {
        public static async System.Threading.Tasks.Task Main(string[] args)
        {
            var hostBuilder = CreateHostBuilder(args).Build();

            using (var scope = hostBuilder.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<FormulaOneDbContext>();                    
                    await context.Database.EnsureCreatedAsync();
                    InitializeDb.Initialize(context);

                    var userSeeder = services.GetRequiredService<IUserRepository>();
                    await userSeeder.SeedUserAsync();
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }
            hostBuilder.Run();
            
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
