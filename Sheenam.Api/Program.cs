//==================================================
// Copyright (c) Coalition Of Good-Hearted Engineers
// Free To Use Comfort and Peace
//==================================================

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sheenam.Api
{
    public class Program
    {
        public static void Main(string[] args) =>
            CreateHostBuilder(args).Build().Run();
        

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            Console.WriteLine("Salom");
           return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
        }
    }
}
