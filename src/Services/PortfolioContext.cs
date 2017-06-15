using System.Linq;
using Microsoft.EntityFrameworkCore;
using ProfilesModel = PortfolioApi.Models.Profiles;
using ContactsModel = PortfolioApi.Models.Contacts;
using InterestsModel = PortfolioApi.Models.Interests;
using RankableItemsModel = PortfolioApi.Models.RankableItems;
using ClientsModel = PortfolioApi.Models.Clients;
using ProjectsModel = PortfolioApi.Models.Projects;
using ContentsModel = PortfolioApi.Models.Contents;

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
        public DbSet<RankableItemsModel.Libraries.Library> Libraries{ get; set; }
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
                entityType.Relational().TableName = entityType.Name.Replace('.', '_').ToLower();
                foreach (var addDateProps in entityType.GetProperties().Where(x => x.Name == "AddDate" || x.Name == "UpdateDate"))
                {
                    addDateProps.Relational().DefaultValueSql = "GETUTCDATE()";
                    // TODO get Update date to automatically update the Date
                }
            }
            // http://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-using-entity-framework-core-code-first/
            //modelBuilder.Entity<RankableItemsModel.Languages.Language>().HasIndex(l => l.Info.Title);
            //modelBuilder.Entity<RankableItemsModel.Frameworks.Framework>().HasIndex(f => f.Info.Title);
            //modelBuilder.Entity<RankableItemsModel.Libraries.Library>().HasIndex(f => f.Info.Title);
            //modelBuilder.Entity<InterestsModel.Interest>().HasIndex(f => f.Info.Description);
            // TODO need to figure out this class stuff
            modelBuilder.Entity<ClientsModel.Client>().Property(x => x.Secret).HasDefaultValueSql("NEWID()");
            //modelBuilder.Entity<ClientsModel.Client>().HasIndex(x => new { x.Info.Name, x.Secret });

        }
    }
}
