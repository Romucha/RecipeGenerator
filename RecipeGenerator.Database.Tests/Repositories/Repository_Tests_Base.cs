using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.Tests.TestData.Repositories.Steps;
using RecipeGenerator.Models;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.Repositories
{
    public abstract class Repository_Tests_Base<T>  where T : class, IRecipeGeneratorModel
    {
        protected readonly ILogger<Repository<T>> logger;
        protected readonly Repository<T> repository;
        protected readonly RecipeGeneratorDbContext dbContext;

        public Repository_Tests_Base()
        {
            logger = new NullLogger<Repository<T>>();
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<RecipeGeneratorDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeGeneratorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            dbContext = new RecipeGeneratorDbContext(configuration, dbContextOptions);
            repository = new Repository<T>(dbContext, logger);
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //act
            var t = await repository.CreateAsync();
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(t);
            Assert.NotNull(dbContext.Entry(t).Entity);
        }

        [Fact]
        public async Task DeleteAsync_Normal()
        {
            //arrange
            T expectedT = Activator.CreateInstance<T>();
            await dbContext.AddAsync(expectedT);
            await dbContext.SaveChangesAsync();

            var id = expectedT.Id;
            //act
            await repository.DeleteAsync(id);
            await dbContext.SaveChangesAsync();
            //assert
            var actualT = dbContext.Find<T>(expectedT.Id);
            Assert.Null(actualT);
        }

        [Fact]
        public async Task GetAsync_Normal()
        {
            //arrange
            T expectedT = Activator.CreateInstance<T>();
            await dbContext.AddAsync(expectedT);
            await dbContext.SaveChangesAsync();

            var id = expectedT.Id;
            //act
            var actualT = await repository.GetAsync(id);
            //assert
            Assert.NotNull(actualT);
            Assert.Equal(expectedT, actualT);
        }

        [Theory]
        [InlineData(-1, -1, 10)]
        [InlineData(0, 0, 10)]
        [InlineData(0, 1, 10)]
        [InlineData(1, 0, 10)]
        [InlineData(1, 1, 1)]
        [InlineData(1, 2, 2)]
        [InlineData(0, int.MaxValue, 10)]
        public async Task GetAllAsync_Normal(int pageNumber, int pageSize, int totalCount)
        {
            //arrange
            T[] expectedTs =
            [
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
                Activator.CreateInstance<T>(),
            ];
            await dbContext.AddRangeAsync(expectedTs);
            await dbContext.SaveChangesAsync();

            //act
            var actualTs = await repository.GetAllAsync(pageNumber, pageSize);
            //assert
            Assert.NotNull(actualTs);
            Assert.Equal(totalCount, actualTs.Count());
        }
    }
}
