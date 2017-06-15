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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.Name.Replace('.', '_').ToLower().Replace("portfolioapi_models", "pfm");
                foreach (var addDateProps in entityType.GetProperties().Where(x => x.Name == "AddDate" || x.Name == "UpdateDate"))
                {
                    addDateProps.Relational().DefaultValueSql = "GETUTCDATE()";
                    // TODO get Update date to automatically update the Date
                }
            }
            // http://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-using-entity-framework-core-code-first/

            // https://blogs.msdn.microsoft.com/dotnet/2017/05/12/announcing-ef-core-2-0-preview-1/
            // untill that is updated, everything will have a an id
            modelBuilder.Entity<ProfilesModel.Profile>().OwnsOne(x => x.Info);
            modelBuilder.Entity<ContactsModel.Contact>().OwnsOne(x => x.Info);
            modelBuilder.Entity<ContactsModel.Addresses.Address>().OwnsOne(x => x.Info);
            modelBuilder.Entity<ContactsModel.Phones.Phone>().OwnsOne(x => x.Info);
            modelBuilder.Entity<RankableItemsModel.Frameworks.Framework>().OwnsOne(x => x.Info);
            modelBuilder.Entity<RankableItemsModel.Languages.Language>().OwnsOne(x => x.Info);
            modelBuilder.Entity<RankableItemsModel.Libraries.Library>().OwnsOne(x => x.Info);
            modelBuilder.Entity<RankableItemsModel.Ranks.Rank>().OwnsOne(x => x.Info);
            modelBuilder.Entity<InterestsModel.Interest>().OwnsOne(x => x.Info);
            modelBuilder.Entity<ProjectsModel.Project>().OwnsOne(x => x.Info);
            modelBuilder.Entity<ClientsModel.Client>().OwnsOne(x => x.Info);
            modelBuilder.Entity<ContentsModel.Content>().OwnsOne(x => x.Info);
            modelBuilder.Entity<ContentsModel.Sections.Section>().OwnsOne(x => x.Info);

            //// TODO need to figure out how to index complex stuff.
            //modelBuilder.Entity<RankableItemsModel.Languages.Info>().HasIndex(l => l.Title);
            //modelBuilder.Entity<RankableItemsModel.Frameworks.Info>().HasIndex(f => f.Title);
            //modelBuilder.Entity<RankableItemsModel.Libraries.Info>().HasIndex(f => f.Title);
            //modelBuilder.Entity<InterestsModel.Info>().HasIndex(f => f.Description);
            //modelBuilder.Entity<ClientsModel.Info>().HasIndex(x => new { x.Name });
            //modelBuilder.Entity<ClientsModel.Client>().HasIndex(x => new { x.Secret });



            // TODO need to figure out this class stuff
            modelBuilder.Entity<ClientsModel.Client>().Property(x => x.Secret).HasDefaultValueSql("NEWID()");

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
