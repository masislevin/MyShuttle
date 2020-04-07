using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyShuttle.Data;
using NUnit.Framework.Internal;
using System;
using System.Threading.Tasks;

namespace MyShuttle.ITests
{
    [TestClass]
    public class MyShuttleContextTests
    {
        [TestMethod]
        public async Task Db_CreatedSuccessfully()
        {
            var options = new DbContextOptionsBuilder<MyShuttleContext>()
                            .UseInMemoryDatabase(Guid.NewGuid().ToString())
                            .Options;
            var context = new MyShuttleContext(options);

            var databaseCreated = await context.Database.EnsureCreatedAsync();
            Assert.IsTrue(databaseCreated);

            var databaseDeleted = await context.Database.EnsureDeletedAsync();
            Assert.IsTrue(databaseDeleted);
        }
    }
}
