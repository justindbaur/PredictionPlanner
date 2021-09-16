global using PredictionPlanner.Storage;
global using PredictionPlanner.Server.Models;
global using PredictionPlanner.Storage.Entities;
global using Microsoft.EntityFrameworkCore;

namespace PredictionPlanner.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
