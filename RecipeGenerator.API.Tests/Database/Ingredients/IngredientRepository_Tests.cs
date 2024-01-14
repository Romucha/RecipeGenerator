using AutoMapper;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Mapping;
using RecipeGenerator.API.Models.Ingeridients;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace RecipeGenerator.API.Tests.Database.Ingredients
{
    public partial class IngredientRepository_Tests : IDisposable
    {
        private readonly IIngredientRepository ingredientRepository;

        private readonly RecipeDbContext recipeDbContext;

        private readonly IMapper mapper;

        public IngredientRepository_Tests()
        {
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            var config = new MapperConfiguration(c => c.AddProfile(new MapperInitializer()));
            mapper = config.CreateMapper();
            IIngredientFactory ingredientFactory = new IngredientFactory(mapper);
            IIngredientGetter ingredientgetter = new IngredientGetter(ingredientFactory);
            DbContextOptions<RecipeDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                                                               .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                                                                                               .Options;
            recipeDbContext = new RecipeDbContext(configuration, ingredientgetter, mapper, dbContextOptions);

            ingredientRepository = new IngredientRepository(recipeDbContext, mapper);
        }

        public void Dispose()
        {
            recipeDbContext.Database.EnsureDeleted();
            recipeDbContext.Dispose();
        }
    }
}
