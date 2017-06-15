using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Swagger;
using PortfolioApi.Services;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Helpers.Swashbuckle.Filters;

namespace PortfolioApi
{
    public partial class Startup
    {
        ILogger _logger;
        public Startup(IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
            _logger = loggerFactory.CreateLogger<Startup>();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            // Register the Swagger generator, defining one or more Swagger documents
            // https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Portfolio API", Version = "v1" });
                c.OperationFilter<AuthorizationHeaderOperationFilter>();
                c.CustomSchemaIds(x => x.FullName);
            });

            // https://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx
            services.AddApiVersioning(o =>
            {
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new ApiVersion(1, 0);
            });

            // Add framework services.
            services.AddDbContext<PortfolioContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection") ??
                    Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, PortfolioContext context)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            ConfigureAuth(app);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio API V1");
            });


            app.UseMvc();

            // Migrate and seed the database during startup. Must be synchronous.
            try
            {
                //http://benjii.me/2017/05/enable-entity-framework-core-migrations-visual-studio-2017/
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<PortfolioContext>().Database.Migrate();
                    _logger.LogInformation("Database Migration passed");

                    //serviceScope.ServiceProvider.GetService<ISeedService>().SeedDatabase().Wait();
                }
            }
            catch (Exception ex)
            {
                //http://ardalis.com/logging-and-using-services-in-startup-in-aspnet-core-apps
                _logger.LogError(0, ex, "Failed to migrate or seed database");
            }

            //Helpers.PortfolioInitializer.Init(context); -- used to seed. This file is ignored in git
        }
    }
}
