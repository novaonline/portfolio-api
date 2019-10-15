using System;
using Microsoft.Extensions.DependencyInjection;
using PortfolioApi.Models.Helpers.Builder;
using PortfolioApi.Repository.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models.Interfaces;
using PortfolioApi.Core.Domains.Contacts;
using PortfolioApi.Core.Domains.Experiences;
using PortfolioApi.Core.Domains.Profiles;

namespace PortfolioApi.Core.Builder
{
    public class PortfolioBuilder
    {
        protected PortfolioConfiguration config;

        public PortfolioBuilder()
        {
            config = new PortfolioConfiguration();
        }

        public void Build(IServiceCollection services)
        {

            // 1. Inject everything needed

            // Inject Repo
            switch (config.MainPersistenceSettings?.PersistenceType ?? config.DefaultPersistenceSettings.PersistenceType)
            {
                case PersistenceType.InMemorySqlSever:
                    services.AddDbContext<PortfolioContext>(opt =>
                    {
                        var cs = config.MainPersistenceSettings?.ConnectionString ?? config.DefaultPersistenceSettings.ConnectionString;
                        opt.UseSqlite(cs);
                    });
                    break;
                case PersistenceType.SqlServer:
                    services.AddDbContext<PortfolioContext>(opt =>
                    {
                        var cs = config.MainPersistenceSettings?.ConnectionString ?? config.DefaultPersistenceSettings.ConnectionString;
                        opt.UseSqlServer(cs);
                    });
                    break;
                default:
                    throw new ArgumentNullException(nameof(config.MainPersistenceSettings), "Main Persistence must have a setting");
            }

            // Inject Domains
            IDependencyInjectionSetup[] domainsForInjection = new IDependencyInjectionSetup[]
            {
                new ContactsDependencyInjectionSetup(),
                new ExperiencesDependencyInjectionSetup(),
                new ProfilesDependencyInjectionSetup()
            };

            foreach (var domainSetup in domainsForInjection)
            {
                domainSetup.Inject(services, config);
            }

        }
    }
}
