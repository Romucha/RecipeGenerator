using AutoMapper;
using Castle.Core.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using RecipeGenerator.Database.Context;
using RecipeGenerator.Database.Repositories;
using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Utility.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Tests.Database.Repositories.ApplicableIngredients
{
    public partial class ApplicableIngredientsRepositoryTests : IDisposable
    {
        private readonly RecipeGeneratorDbContext recipeGeneratorDbContext;

        private readonly ApplicableIngredientRepository repository;
        public ApplicableIngredientsRepositoryTests()
        {
            var configuration = new Mock<Microsoft.Extensions.Configuration.IConfiguration>().Object;
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<MapperInitializer>()).CreateMapper();

            DbContextOptions options = new DbContextOptionsBuilder<RecipeGeneratorDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            recipeGeneratorDbContext = new RecipeGeneratorDbContext(configuration, options);

            repository = new ApplicableIngredientRepository(
                new NullLogger<ApplicableIngredientRepository>(),
                recipeGeneratorDbContext,
                mapper);
        }

        public void Dispose()
        {
            recipeGeneratorDbContext.Dispose();
        }
    }
}
