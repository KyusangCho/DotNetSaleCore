using DotNetSaleCore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNetSaleCore.Tests
{
    

    [TestClass]
    public class CustomerRepositoryAsyncTest
    {

        [TestMethod]
        public async void CustomerRepositoryAsyncAllMethodTest()
        {
            // DbContextOptions<T> object creation
            var options = new DbContextOptionsBuilder<DotNetSaleCoreDbContext>()
                .UseInMemoryDatabase(databaseName: $"DotNetSaleCore{Guid.NewGuid()}").Options;

            // ILoggerFactory Object creation 
            var serviceProvider = new ServiceCollection().AddLogging().BuildServiceProvider();
            var factory = serviceProvider.GetService<ILoggerFactory>(); 

            // [1] AddAsync() method test 
            using(var context = new DotNetSaleCoreDbContext(options))
            {
                // Repository Object Creation
                // [!] Arrange
                var repository = new CustomerRepositoryAsync(context, factory);
                var model = new Customer { CustomerName = "[1] 고객이름", Created = DateTime.Now };

                // [!] Act 
                await repository.AddAsync(model);
                await context.SaveChangesAsync(); 
            }

            using (var context = new DotNetSaleCoreDbContext(options))
            {
                // [!] Assert
                Assert.AreEqual(1, await context.Customers.CountAsync());
                var model = await context.Customers.Where(m => m.CustomerId == 1).SingleOrDefaultAsync();
                Assert.AreEqual("[1] 고객이름", model?.CustomerName); 
            }
        }
    }
}
