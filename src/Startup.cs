using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PortfolioApi.Repository.EntityFramework.Context;
using Swashbuckle.AspNetCore.Swagger;
using System;

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
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader()
                                    .AllowCredentials();

                });

            });
            // Add framework services.
            services.AddMvc(options =>
            {
                options.CacheProfiles.Add("Default", new CacheProfile() { Duration = 60 });
                options.CacheProfiles.Add("ContentCache", new CacheProfile() { Duration = 86400 });

            });
            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .Build();
            });

            services.AddAuthentication(o =>
            {
                o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            });


            // Register the Swagger generator, defining one or more Swagger documents
            // https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Portfolio API", Version = "v1" });
                c.CustomSchemaIds(x => x.FullName);
            });

            // // https://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx
            // services.AddApiVersioning(o =>
            // {
            //     o.AssumeDefaultVersionWhenUnspecified = true;
            //     o.DefaultApiVersion = new ApiVersion(1, 0);
            // });

            // Add framework services.
            services.AddDbContext<PortfolioContext>(options =>
                options.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection") ??
                    Configuration.GetConnectionString("DefaultConnection"))
                    );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, PortfolioContext context)
        {
            //TODO
            //'ConsoleLoggerExtensions.AddConsole(ILoggerFactory, IConfiguration)' is obsolete: 
            //'This method is obsolete and will be removed in a future version. 
            //The recommended alternative is to call the Microsoft.Extensions.Logging.AddConsole() extension method on the Microsoft.Extensions.Logging.LoggerFactory instance.' 

            // global policy - assign here or on each controller
            app.UseCors("CorsPolicy");


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

            //Helpers.PortfolioInitializer.Init(context); // used to seed. This file is ignored in git
        }
    }
}
