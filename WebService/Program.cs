using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataServiceLib;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace ProjectPortfolio2_Group11
{
    public class Program
    {
        public static void Main(string[] args)
        {
           CreateHostBuilder(args).Build().Run();
           /* var config = new ConfigurationBuilder()
               .AddJsonFile("config.json")
               .AddEnvironmentVariables()
               .Build();
           var dataService = new DataService(config["connectionString"]);
           foreach (var elem in dataService.GetActorsKnownForTitles())
           {
               Console.Write(elem);    
           }*/
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}