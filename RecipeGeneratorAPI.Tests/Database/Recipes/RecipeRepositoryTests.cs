using Microsoft.EntityFrameworkCore;
using Moq;
using RecipeGenerator.API.Database.Ingredients;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using RecipeGenerator.API.Database.Recipes;
using Microsoft.EntityFrameworkCore.Diagnostics;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using RecipeGeneratorAPI.Tests.Samples;

namespace RecipeGeneratorAPI.Tests.Database.Recipes
{
    public class RecipeRepositoryTests
    {
        private readonly IRecipeRepository recipeRepository;

        private readonly RecipeDbContext recipeDbContext;

        public RecipeRepositoryTests()
        {
            IConfiguration configuration = new Mock<IConfiguration>().Object;
            IIngredientFactory ingredientFactory = new IngredientFactory();
            IIngredientGetter ingredientgetter = new IngredientGetter(ingredientFactory);
            DbContextOptions<RecipeDbContext> dbContextOptions = new DbContextOptionsBuilder<RecipeDbContext>().UseInMemoryDatabase(Guid.NewGuid().ToString())
                                                                                                               .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning)).Options; ;
            recipeDbContext = new RecipeDbContext(configuration, ingredientgetter, dbContextOptions);

            recipeRepository = new RecipeRepository(recipeDbContext);
        }

        #region Get Recipe Tests
        [Fact]
        public async Task GetAllRecipes_Normal()
        {
            recipeRepository.GetAll();
        }
        #endregion

        #region Add Recipe Tests
        [Fact]
        public async Task AddRecipe_Normal()
        {
            //arrange
            var recipe = RecipeSamples.NormalRecipe;
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task AddRecipe_Default()
        {
            //arrange
            var recipe = RecipeSamples.DefaultRecipe;
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task AddRecipe_Empty()
        {
            //arrange
            var recipe = RecipeSamples.EmptyRecipe;
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task AddRecipe_Null()
        {
            //arrange
            var recipe = RecipeSamples.NullRecipe;
            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await recipeRepository.Add(recipe));
        }
        #endregion

        #region Detele Recipe Tests

        #endregion

        #region Update Recipe Tests

        #endregion
    }
}
