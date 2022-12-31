using Mc2.CrudTest.Presentation.Server.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace Mc2.CrudTest.AcceptanceTests
{
    public class AppDbContextFixture
    {
        private static readonly object _lock = new();
        private static bool _databaseInitialized;

        public AppDbContextFixture()
        {
            lock (_lock)
            {
                if (!_databaseInitialized)
                {
                    using (var context = CreateContext())
                    {

                    }

                    _databaseInitialized = true;
                }
            }
        }

        public ApplicationDbContext CreateContext()
        {
            var config = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("appsettings.json", false, true)
            .Build();

            return new ApplicationDbContext(
                new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(config.GetConnectionString("DataBaseConnection"))
                    .Options);
        }
    }
}