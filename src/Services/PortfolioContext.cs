using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProfilesModel = PortfolioApi.Models.Profiles;
using ContactsModel = PortfolioApi.Models.Contacts;
using InterestsModel = PortfolioApi.Models.Interests;
using RankableItemsModel = PortfolioApi.Models.RankableItems;
using ClientsModel = PortfolioApi.Models.Clients;
using ProjectsModel = PortfolioApi.Models.Projects;
using ContentsModel = PortfolioApi.Models.Contents;
using System;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Logging;
using PortfolioApi.Helpers;

namespace PortfolioApi.Services
{
    // https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/migrations
    // https://stackoverflow.com/questions/175415/how-do-i-get-list-of-all-tables-in-a-database-using-tsql
    // http://ef.readthedocs.io/en/staging/modeling/relational/default-values.html?highlight=default
    // https://docs.microsoft.com/en-us/ef/core/modeling/relational/default-values
    // https://docs.microsoft.com/en-us/ef/core/querying/related-data
    // https://www.codeproject.com/Articles/1155666/Creating-Angular-Application-with-ASP-NET-Core-Tem
    public class PortfolioContext : DbContext
    {
        public DbSet<ProfilesModel.Profile> Profiles { get; set; }
        public DbSet<ContactsModel.Contact> Contacts { get; set; }
        public DbSet<RankableItemsModel.Frameworks.Framework> Frameworks { get; set; }
        public DbSet<RankableItemsModel.Languages.Language> Languages { get; set; }
        public DbSet<RankableItemsModel.Libraries.Library> Libraries { get; set; }
        public DbSet<RankableItemsModel.Ranks.Rank> Ranks { get; set; }
        public DbSet<InterestsModel.Interest> Interests { get; set; }
        public DbSet<ProjectsModel.Project> Projects { get; set; }
        public DbSet<ClientsModel.Client> Clients { get; set; }
        public DbSet<ContentsModel.Content> Contents { get; set; }
        public DbSet<ContentsModel.Sections.Section> Sections { get; set; }

        public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            LoggerFactory loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new TraceLoggerProvider());
            optionsBuilder.UseLoggerFactory(loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://blogs.msdn.microsoft.com/dotnet/2017/05/12/announcing-ef-core-2-0-preview-1/
            // will need to wait till an update comes before these are columns and not tables
            modelBuilder.Entity<ClientsModel.Client>(entity =>
            {
                entity.HasIndex(x => new { x.Name, x.Secret }).IsUnique();
                entity.Property(x => x.Secret).HasDefaultValueSql("NEWID()");
            });

            modelBuilder.Entity<ProfilesModel.Profile>(entity =>
            {
                entity.OwnsOne(x => x.Info);

            });
            modelBuilder.Entity<ContactsModel.Contact>(entity =>
            {
                entity.OwnsOne(x => x.Info);
            });
            modelBuilder.Entity<RankableItemsModel.Frameworks.Framework>(entity =>
            {
                entity.HasIndex(x => x.Title);
                entity.OwnsOne(x => x.Info);
            });
            modelBuilder.Entity<RankableItemsModel.Languages.Language>(entity =>
            {
                entity.HasIndex(x => x.Title);
                entity.OwnsOne(x => x.Info);
            });
            modelBuilder.Entity<RankableItemsModel.Libraries.Library>(entity =>
            {
                entity.HasIndex(x => x.Title);
                entity.OwnsOne(x => x.Info);
            });
            modelBuilder.Entity<RankableItemsModel.Ranks.Rank>(entity =>
            {
                entity.OwnsOne(x => x.Info);
            });
            modelBuilder.Entity<InterestsModel.Interest>(entity =>
            {
                entity.OwnsOne(x => x.Info);
            });
            modelBuilder.Entity<ProjectsModel.Project>(entity =>
            {
                entity.HasIndex(x => x.Title);
                entity.OwnsOne(x => x.Info);
            });
            modelBuilder.Entity<ContentsModel.Content>(entity => {
                entity.HasIndex(x => x.HtmlId);
                entity.OwnsOne(x => x.Info);
                //entity.HasMany(x => x.Sections);
            });
            modelBuilder.Entity<ContentsModel.Sections.Section>(entity =>
            {
                entity.OwnsOne(x => x.Info);
            });

            // http://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-using-entity-framework-core-code-first/
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.Name.Replace('.', '_').ToLower().Replace("portfolioapi_models", "pfm");
                foreach (var dateProp in entityType.GetProperties().Where(x => x.Name == "AddDate" || x.Name == "UpdateDate"))
                {
                    if (dateProp.Name == "UpdateDate")
                    {
                        dateProp.Relational().ComputedColumnSql = "GETUTCDATE()";
                    }
                    else
                    {
                        dateProp.Relational().DefaultValueSql = "GETUTCDATE()";
                    }
                }
            }
        }
    }

    public class TempDbContextFactory : IDbContextFactory<PortfolioContext>
    {
        public PortfolioContext Create(string[] options)
        {
            //http://benjii.me/2016/05/dotnet-ef-migrations-for-asp-net-core/
            var builder = new DbContextOptionsBuilder<PortfolioContext>();
            builder.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection"));
            return new PortfolioContext(builder.Options);
        }
    }
}
