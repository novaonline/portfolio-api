using System;
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Repository.EntityFramework.Context;

namespace PortfolioApi.Tests.Integration
{
    public class DatabaseFixture : IDisposable
    {
        public PortfolioContext _portfolioContext { get; private set; }

        public DatabaseFixture()
        {
            var options = new DbContextOptionsBuilder<PortfolioContext>()
                .UseSqlite("DataSource=:memory:")
                .Options;
            _portfolioContext = new PortfolioContext(options);
            _portfolioContext.Database.OpenConnection();
            _portfolioContext.Database.EnsureCreated();
        }
        public void Dispose()
        {
           // _portfolioContext.Dispose();
        }
    }
}
