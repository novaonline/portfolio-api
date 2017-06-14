using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;

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
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<FrameworksAndLibs> FrameworksAndLibs { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Rank> Ranks { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<Section> Sections { get; set; }
        
        public PortfolioContext(DbContextOptions<PortfolioContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.Name.Replace('.', '_').ToLower();
                foreach (var addDateProps in entityType.GetProperties().Where(x => x.Name == "AddDate"))
                {
                    addDateProps.Relational().DefaultValueSql = "GETUTCDATE()";
                }
            }
            // http://www.c-sharpcorner.com/article/crud-operations-in-asp-net-core-using-entity-framework-core-code-first/
            modelBuilder.Entity<Language>().HasIndex(l => l.Title);
            modelBuilder.Entity<FrameworksAndLibs>().HasIndex(f => f.Title);
            modelBuilder.Entity<Interest>().HasIndex(f => f.Description);
            modelBuilder.Entity<Client>().Property(x => x.Secret).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<Client>().HasIndex(x => new { x.Name, x.Secret });

        }
    }
}
