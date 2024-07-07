using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Database.UnitsOfWork;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Database.Tests.UnitsOfWork
{
    public abstract class UnitOfWork_Tests_Base
    {
        protected readonly IUnitOfWork unitOfWork;
        protected readonly RecipeGeneratorDbContext dbContext;

        public UnitOfWork_Tests_Base()
        {
            ILogger<UnitOfWork> uowLogger = new NullLogger<UnitOfWork>();
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<RecipeGeneratorDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeGeneratorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            dbContext = new RecipeGeneratorDbContext(configuration, dbContextOptions);

            ILogger<Repository<ApplicableIngredient>> raiLogger = new NullLogger<Repository<ApplicableIngredient>>();
            IRepository<ApplicableIngredient> applicableIngredientRepository = new Repository<ApplicableIngredient>(dbContext, raiLogger);

            ILogger<Repository<AppliedIngredient>> raidLogger = new NullLogger<Repository<AppliedIngredient>>();
            IRepository<AppliedIngredient> appliedIngredientRepository = new Repository<AppliedIngredient>(dbContext, raidLogger);

            ILogger<Repository<Step>> stepLogger = new NullLogger<Repository<Step>>();
            IRepository<Step> stepRepository = new Repository<Step>(dbContext, stepLogger);

            ILogger<Repository<Recipe>> recipeLogger = new NullLogger<Repository<Recipe>>();
            IRepository<Recipe> recipeRepository = new Repository<Recipe>(dbContext, recipeLogger);

            var config = new MapperConfiguration(c => c.AddProfile(new MapperInitializer()));
            IMapper mapper = config.CreateMapper();

            unitOfWork = new UnitOfWork(
                uowLogger,
                dbContext,
                recipeRepository,
                stepRepository,
                appliedIngredientRepository,
                applicableIngredientRepository,
                mapper);
        }
        [Fact]
        public abstract Task CreateAsync_Normal();

        [Fact]
        public abstract Task DeleteAsync_Normal();

        [Fact]
        public abstract Task UpdateAsync_Normal();

        [Fact]
        public abstract Task GetAsync_Normal();

        [Fact]
        public abstract Task GetAllAsync_Normal();
    }
}
