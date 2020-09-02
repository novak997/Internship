using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TimeSheet.Models;
using TimeSheet.Repositories;

namespace TimeSheet
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
                    /*CategoryRepository categoryRepository = new CategoryRepository();
                    Category category = new Category
                    {
                        Name = "backend"
                    };
                    categoryRepository.AddCategory(category);
                    System.Diagnostics.Debug.WriteLine("tako nesto");
                    */
                });
    }
}
