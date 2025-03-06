using Catalog.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Tests.Configuration
{
    public static class ApplicationDbContextInMemory
    {
        public static CatalogDbContext Get()
        {
            var options = new DbContextOptionsBuilder<CatalogDbContext>()
                    .UseInMemoryDatabase(databaseName: $"Catalog.Db")
                    .Options;

            return new CatalogDbContext(options);
        }
    }
}
