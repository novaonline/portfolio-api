using Microsoft.EntityFrameworkCore;
using System.Linq;
using ClientsModel = PortfolioApi.Models.Clients;
using ContactsModel = PortfolioApi.Models.Contacts;
using ProfilesModel = PortfolioApi.Models.Profiles;
using ExperiencseModel = PortfolioApi.Models.Experiences;
using IdentityItemModel = PortfolioApi.Models.IdentityItem;

namespace PortfolioApi.Repository.EntityFramework.Context
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
        public DbSet<ClientsModel.Client> Clients { get; set; }
        public DbSet<ExperiencseModel.Experience> Experiences { get; set; }

        public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityItemModel>(entity =>
            {
                entity.HasIndex(x => new { x.Id }).IsUnique();
                entity.Property(x => x.Id).HasDefaultValueSql("NEWID()");
                entity.Property(x => x.Id).UseIdentityColumn();
            });

            // https://blogs.msdn.microsoft.com/dotnet/2017/05/12/announcing-ef-core-2-0-preview-1/
            // will need to wait till an update comes before these are columns and not tables
            modelBuilder.Entity<ClientsModel.Client>(entity =>
            {
                entity.HasIndex(x => new { x.Name, x.Secret }).IsUnique();
                entity.Property(x => x.Secret).HasDefaultValueSql("NEWID()");
                entity.Property(x => x.Secret).UseIdentityColumn();
            });

            modelBuilder.Entity<ProfilesModel.Profile>(entity =>
            {
                entity.OwnsOne(x => x.Info);
                entity.HasIndex(x => new {x.Info.LastName, x.Info.FirstName});
            });
            modelBuilder.Entity<ContactsModel.Contact>(entity =>
            {
                entity.OwnsOne(x => x.Info);
            });
            modelBuilder.Entity<ExperiencseModel.Experience>(entity =>
            {
                entity.HasIndex(x => x.Type);
                entity.HasIndex(x => x.Info.Title);
                entity.OwnsOne(x => x.Info);
            });

            // http://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-using-entity-framework-core-code-first/
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var dateProp in entityType.GetProperties().Where(x => x.Name == "AddDate" || x.Name == "UpdateDate"))
                {
                    if (dateProp.Name == "UpdateDate")
                    {
                        dateProp.SetComputedColumnSql("GETUTCDATE()");
                    }
                    else
                    {
                        dateProp.SetDefaultValueSql("GETUTCDATE()");
                    }
                }
            }
        }
    }
}
