using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using CustomTokenAuthProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PortfolioApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace PortfolioApi
{
    public partial class Startup
    {
        public SymmetricSecurityKey signingKey;
        private void ConfigureAuth(IApplicationBuilder app)
        {

            signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("TokenAuthentication_SecretKey") ?? Configuration.GetSection("TokenAuthentication:SecretKey").Value));

            var tokenProviderOptions = new TokenProviderOptions
            {
                Path = Configuration.GetSection("TokenAuthentication:TokenPath").Value,
                Audience = Configuration.GetSection("TokenAuthentication:Audience").Value,
                Issuer = Configuration.GetSection("TokenAuthentication:Issuer").Value,
                SigningCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                IdentityResolver = GetIdentity
            };

            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    TokenValidationParameters = tokenValidationParameters
            //});
            app.UseAuthentication();
            app.UseMiddleware<TokenProviderMiddleware>(Options.Create(tokenProviderOptions));
        }

        private Task<ClaimsIdentity> GetIdentity(string name, string secret)
        {
            var optionsBuilder = new DbContextOptionsBuilder<PortfolioContext>();
            optionsBuilder.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection") ?? Configuration.GetConnectionString("DefaultConnection"));
            PortfolioApi.Models.Clients.Client client;
            using (var contenxt = new PortfolioContext(optionsBuilder.Options))
            {
                client = contenxt.Clients.Where(c => c.Secret == secret && c.Name == name).FirstOrDefault();
            }

            if (client != null)
            {
                return Task.FromResult(new ClaimsIdentity(new GenericIdentity(name, "Token"), new Claim[] { }));
            }

            // Account doesn't exists
            return Task.FromResult<ClaimsIdentity>(null);
        }
    }
}
