using Microsoft.EntityFrameworkCore;
using ContactsModel = PortfolioApi.Models.Contacts;
using ProfilesModel = PortfolioApi.Models.Profiles;
using ExperiencseModel = PortfolioApi.Models.Experiences;
using System;

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
            // TODO: Need to add entity conventions
            modelBuilder.HasDefaultSchema("Portfolio");

            modelBuilder.Entity<ProfilesModel.Profile>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                
                entity.HasIndex(x => x.OwnerUserId);

                entity.OwnsOne(x => x.Info, inf =>
                {
                    inf.HasIndex(x => new { x.LastName, x.FirstName });
                });

                entity.Property(p => p.UpdateDate).HasDefaultValue(DateTime.UtcNow);
                entity.Property(p => p.AddDate).HasDefaultValue(DateTime.UtcNow);
            });

            modelBuilder.Entity<ContactsModel.Contact>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                
                entity.HasIndex(x => x.OwnerUserId);

                entity.OwnsOne(x => x.Info, inf =>
                {
                    inf.HasIndex(x => x.Email);
                });

                entity.Property(p => p.UpdateDate).HasDefaultValue(DateTime.UtcNow);
                entity.Property(p => p.AddDate).HasDefaultValue(DateTime.UtcNow);
            });

            modelBuilder.Entity<ExperiencseModel.Experience>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Id).UseIdentityColumn();
                
                entity.HasIndex(x => x.OwnerUserId);
                entity.HasIndex(x => x.Type);
                
                entity.OwnsOne(x => x.Info, inf =>
                {
                    inf.OwnsMany(x => x.Sections, s =>
                    {
                        s.OwnsOne(si => si.Info);
                    });
                    inf.HasIndex(x => x.Title);
                });

                entity.Property(p => p.UpdateDate).HasDefaultValue(DateTime.UtcNow);
                entity.Property(p => p.AddDate).HasDefaultValue(DateTime.UtcNow);
            });
        }
    }
}
