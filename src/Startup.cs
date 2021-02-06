using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using PortfolioApi.Core.Builder;
using PortfolioApi.Helpers.Authorization;
using PortfolioApi.Helpers.Swagger;
using PortfolioApi.Models.Helpers.Builder;
using PortfolioApi.Repository.EntityFramework.Context;
using Swashbuckle.AspNetCore.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace PortfolioApi
{
	/// <summary>
	/// 
	/// </summary>
	public partial class Startup
	{
		ILogger _logger;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="env"></param>
		/// <param name="loggerFactory"></param>
		public Startup(IWebHostEnvironment env, ILoggerFactory loggerFactory)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();
			_logger = loggerFactory.CreateLogger<Startup>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <value></value>
		public IConfigurationRoot Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		public void ConfigureServices(IServiceCollection services)
		{
			var apiName = Configuration["IdentityServer:ApiName"];
			services.AddCors(options =>
			{
				options.AddPolicy("CorsPolicy", builder =>
				{
					builder
									.AllowAnyMethod()
									.AllowAnyHeader()
									.AllowCredentials();
				});

			});

			services.AddLogging(options =>
			{
				options.AddConsole();
			});

			// Add framework services.
			services.AddControllers(options =>
			{
				options.CacheProfiles.Add("Default", new CacheProfile() { Duration = 60 });
				options.CacheProfiles.Add("ContentCache", new CacheProfile() { Duration = 86400 });

			})
			.AddJsonOptions(options =>
			{
				options.JsonSerializerOptions.WriteIndented = true;
				options.JsonSerializerOptions.IgnoreNullValues = true;
				//options.JsonSerializerOptions.Converters.Add(new StringEnumConverter()); 
			});

			services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
				.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, o =>
				{
					o.Authority = Configuration["IdentityServer:Authority"];

					// https://identityserver4.readthedocs.io/en/latest/topics/resources.html#refresources
					o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters { ValidateAudience = false };
				});
			services.AddSingleton<IAuthorizationHandler, IdentityServerPermissionAuthorizationHandler>();
			services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
			services.AddAuthorization(options =>
			{
				options.AddPolicy("IdentityServerPermissionsPolicy", policy => policy.Requirements.Add(new IdentityServerAuthorizationPermissionRequirement(apiName)));
				options.AddPolicy("AuthorizeAsReadPolicy", policy => policy.Requirements.Add(new IdentityServerAuthorizationPermissionRequirement(apiName, authorizeAsRead: true)));
			});


			// Register the Swagger generator, defining one or more Swagger documents
			// https://docs.microsoft.com/en-us/aspnet/core/tutorials/web-api-help-pages-using-swagger
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Portfolio API", Version = "v1" });
				c.CustomSchemaIds(x => x.FullName);
				var authServer = new Uri(Configuration["IdentityServer:Authority"]);
				c.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
				{
					Type = SecuritySchemeType.OAuth2,
					OpenIdConnectUrl = authServer,
					Flows = new OpenApiOAuthFlows
					{
						ClientCredentials = new OpenApiOAuthFlow
						{
							AuthorizationUrl = new UriBuilder(authServer) { Path = "connect/authorize" }.Uri,
							TokenUrl = new UriBuilder(authServer) { Path = "connect/token" }.Uri,
							Scopes = new Dictionary<string, string> {
								{ $"{apiName}.read", "Read" },
								{ $"{apiName}.write", "Write" },
								{ $"{apiName}.delete", "Delete" },
								{ $"{apiName}.manage", "Manage" }
							}
						},
						AuthorizationCode = new OpenApiOAuthFlow
						{
							AuthorizationUrl = new UriBuilder(authServer) { Path = "connect/authorize" }.Uri,
							TokenUrl = new UriBuilder(authServer) { Path = "connect/token" }.Uri,
							Scopes = new Dictionary<string, string> {
								{ $"{apiName}.read", "Read" },
								{ $"{apiName}.write", "Write" },
								{ $"{apiName}.delete", "Delete" },
								{ $"{apiName}.manage", "Manage" },
							}
						}
					}
				});
				c.OperationFilter<AuthorizeCheckOperationFilter>();

				// Set the comments path for the Swagger JSON and UI.
				var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
				c.IncludeXmlComments(xmlPath);
			});

			// // https://www.hanselman.com/blog/ASPNETCoreRESTfulWebAPIVersioningMadeEasy.aspx
			services.AddApiVersioning(o =>
			{
				o.AssumeDefaultVersionWhenUnspecified = true;
				o.DefaultApiVersion = new ApiVersion(1, 0);
			});

			PortfolioFactory.NewFactory.SetDefaultPersistence(o =>
			{
				o.ConnectionString = Configuration.GetConnectionString("DefaultConnection");
				o.PersistenceType = PersistenceType.SqlServer;
			}).Build(services);

		}


		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		/// <param name="app"></param>
		/// <param name="env"></param>
		/// <param name="context"></param>
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PortfolioContext context)
		{
			app.UseStaticFiles();

			// global policy - assign here or on each controller
			app.UseCors("CorsPolicy");

			// Enable middleware to serve generated Swagger as a JSON endpoint.
			app.UseSwagger();

			// Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "Portfolio API V1");
				c.RoutePrefix = string.Empty;  // Set Swagger UI at apps root
				c.OAuthClientId(Configuration["IdentityServer:Defaults:ClientId"]);
				c.OAuthClientSecret(Configuration["IdentityServer:Defaults:ClientSecret"]);
				c.OAuthAppName("Portfolio API");
				c.OAuthUsePkce();
			});

			app.UseRouting();
			app.UseAuthentication();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
