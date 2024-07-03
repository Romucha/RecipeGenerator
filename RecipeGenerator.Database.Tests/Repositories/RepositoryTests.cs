using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.Repositories
{
    public class RepositoryTests
    {
        private readonly ILogger<Repository<Step>> logger;
        private readonly Repository<Step> repository;
        private readonly RecipeGeneratorDbContext dbContext;

        public RepositoryTests()
        {
            logger = new NullLogger<Repository<Step>>();
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<RecipeGeneratorDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeGeneratorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            dbContext = new RecipeGeneratorDbContext(configuration, dbContextOptions);
            repository = new Repository<Step>(dbContext, logger);
        }

        [Fact]
        public async Task GetAsync_Normal()
        {
            //arrange
            Step expectedStep = new Step()
            {
                Name = nameof(GetAsync_Normal),
                Description = nameof(GetAsync_Normal),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Index = 1,
                Photos = [],
            };
            await dbContext.AddAsync(expectedStep);
            await dbContext.SaveChangesAsync();

            var id = expectedStep.Id;
            //act
            var actualStep = await repository.GetAsync(id);
            //assert
            Assert.NotNull(actualStep);
            Assert.Equal(expectedStep, actualStep);
        }

        [Fact]
        public async Task GetAllAsync_Normal()
        {
            //arrange
            Step[] expectedSteps =
            [
                new Step()
                {
                    Name = nameof(GetAllAsync_Normal),
                    Description = nameof(GetAllAsync_Normal),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Index = 1,
                    Photos = [],
                },
                new Step()
                {
                    Name = nameof(GetAllAsync_Normal),
                    Description = nameof(GetAllAsync_Normal),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow,
                    Index = 2,
                    Photos = [],
                }
            ];
            ;
            await dbContext.AddRangeAsync(expectedSteps);
            await dbContext.SaveChangesAsync();

            //act
            var actualSteps = await repository.GetAllAsync();
            //assert
            Assert.NotNull(actualSteps);
            Assert.NotEmpty(actualSteps);
            Assert.Equal(expectedSteps.Count(), actualSteps.Count());
        }

        [Fact]
        public async Task CreateAsync_Normal()
        {
            //act
            var step = await repository.CreateAsync();
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(step);
            Assert.NotNull(dbContext.Find<Step>(step.Id));
        }

        [Fact]
        public async Task DeleteAsync_Normal()
        {
            //arrange
            Step expectedStep = new Step()
            {
                Name = nameof(DeleteAsync_Normal),
                Description = nameof(DeleteAsync_Normal),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Index = 1,
                Photos = [],
            };
            await dbContext.AddAsync(expectedStep);
            await dbContext.SaveChangesAsync();

            var id = expectedStep.Id;
            //act
            await repository.DeleteAsync(id);
            await dbContext.SaveChangesAsync();
            //assert
            Assert.Null(dbContext.Find<Step>(id));
        }

        [Fact]
        public async Task UpdateAsync_Normal()
        {
            //arrange
            Step expectedStep = new Step()
            {
                Name = nameof(UpdateAsync_Normal),
                Description = nameof(UpdateAsync_Normal),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Index = 1,
                Photos = [],
            };
            await dbContext.AddAsync(expectedStep);
            await dbContext.SaveChangesAsync();

            var id = expectedStep.Id;
            var actualStep = await repository.GetAsync(id);
            //act
            actualStep!.Description = "";
            await dbContext.SaveChangesAsync();
            //assert
            Assert.NotNull(actualStep);
            Assert.Equal(expectedStep, actualStep);
            Assert.Equal("", actualStep.Description);
        }
    }
}
