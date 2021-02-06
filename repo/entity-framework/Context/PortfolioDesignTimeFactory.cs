using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace PortfolioApi.Repository.EntityFramework.Context
{
	public class PortfolioDesignTimeFactory : IDesignTimeDbContextFactory<PortfolioContext>
	{
		public PortfolioContext CreateDbContext(string[] args)
		{
			var opt = new DbContextOptionsBuilder<PortfolioContext>();
			opt.UseSqlServer(Environment.GetEnvironmentVariable("DefaultConnection"));
			return new PortfolioContext(opt.Options);
		}
	}
}
