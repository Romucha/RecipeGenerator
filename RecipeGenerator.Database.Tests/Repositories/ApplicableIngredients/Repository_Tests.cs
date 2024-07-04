using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Logging;
using Moq;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeGenerator.Models.Ingredients;

namespace RecipeGenerator.Database.Tests.Repositories.ApplicableIngredients
{
    public partial class Repository_Tests
    {
        private readonly ILogger<Repository<ApplicableIngredient>> logger;
        private readonly Repository<ApplicableIngredient> repository;
        private readonly RecipeGeneratorDbContext dbContext;

        public Repository_Tests()
        {
            logger = new NullLogger<Repository<ApplicableIngredient>>();
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            DbContextOptions<RecipeGeneratorDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeGeneratorDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options;
            dbContext = new RecipeGeneratorDbContext(configuration, dbContextOptions);
            repository = new Repository<ApplicableIngredient>(dbContext, logger);
        }
    }
}
