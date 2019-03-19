using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Autofac;
using Xunit;
using Newtonsoft.Json.Linq;

namespace BranchOfficeBackend.Tests
{
    public class ServerIntegrationTest : IDisposable
    {
        private BranchOfficeDbContext dbContext;

        public ServerIntegrationTest()
        {
            dbContext = new BranchOfficeDbContext();
            dbContext.Database.Migrate();
        }

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Dispose();
            }
        }

         /// <summary>
        /// Test that API server returns 1 employee JSON list when 
        /// we added 1 employee to db.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task ShouldReturnJsonListOfEmployees()
        {
            await dbContext.Employees.AddAsync(new Employee{ Name = "Ola Dwa", Email = "ola2@gmail.com" });
            await dbContext.SaveChangesAsync();

            using(var testServer = new TestServerBuilder()
                .With(b => b.RegisterModule<BranchOfficeAutofacModule>())
                .Build()) 
            {
                var client = testServer.CreateClient();
                var result = await client.GetStringAsync("/employee/list");
                var items = JArray.Parse(result);
                Assert.Equal(1, items.Count);
            }
        }

    }
}