using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeGeneratorAPI.Tests.Samples;

namespace RecipeGeneratorAPI.Tests.Database.Recipes
{
    [Collection("RecipeRepository")]
    public class RecipeRepository_GetAll_Tests : IDisposable
    {
        private readonly IRecipeRepository recipeRepository;

        private readonly RecipeDbContext recipeDbContext;

        public RecipeRepository_GetAll_Tests()
        {
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            IIngredientFactory ingredientFactory = new IngredientFactory();
            IIngredientGetter ingredientgetter = new IngredientGetter(ingredientFactory);
            DbContextOptions<RecipeDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                                                               .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                                                                                               .Options;
            recipeDbContext = new RecipeDbContext(configuration, ingredientgetter, dbContextOptions);

            recipeRepository = new RecipeRepository(recipeDbContext);
        }

        [Fact]
        public async Task GetAll_Normal()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act
            var recipes = recipeRepository.GetAll();
            //assert
            Assert.NotNull(recipes);
            Assert.NotEmpty(recipes);
        }

        public void Dispose()
        {
            recipeDbContext.Database.EnsureDeleted();
            recipeDbContext.Dispose();
        }
    }
}
