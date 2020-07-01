﻿using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PortfolioApi.Repository.EntityFramework.Context;

namespace PortfolioApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
                .UseKestrel()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseIISIntegration()
                .UseStartup<Startup>()
                .Build();

            // Migrate and seed the database during startup.
            using (var serviceScope = host.Services.CreateScope())
            {
                var ptContext = serviceScope.ServiceProvider.GetService<PortfolioContext>();
                var logger = serviceScope.ServiceProvider.GetService<ILogger<Program>>();
                try
                {
                    ptContext.Database.EnsureCreated();
                    ptContext.Database.Migrate();
                    //serviceScope.ServiceProvider.GetService<ISeedService>().SeedDatabase().Wait();
                    logger.LogInformation("Database Migration passed");

                }
                catch (Exception ex)
                {
                    logger.LogError(0, ex, "Failed to migrate or seed database");
                }
            }


            host.Run();
        }
    }
}
