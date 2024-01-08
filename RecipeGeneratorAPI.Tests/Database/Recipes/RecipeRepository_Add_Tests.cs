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
    [Collection("RecipeRepository")]
    public class RecipeRepository_Add_Tests : IDisposable
    {
        private readonly IRecipeRepository recipeRepository;

        private readonly RecipeDbContext recipeDbContext;

        public RecipeRepository_Add_Tests()
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
        public async Task Add_Normal()
        {
            //arrange
            var recipe = RecipeSamples.NormalRecipe;
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task Add_Default()
        {
            //arrange
            var recipe = RecipeSamples.DefaultRecipe;
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task Add_Empty()
        {
            //arrange
            var recipe = RecipeSamples.EmptyRecipe;
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task Add_Null()
        {
            //arrange
            var recipe = RecipeSamples.NullRecipe;
            //act && assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await recipeRepository.Add(recipe));
        }

        [Fact]
        public async Task Add_ExistingId()
        {
            //arrange
            recipeDbContext.Recipes.Add(RecipeSamples.NormalRecipe);
            await recipeDbContext.SaveChangesAsync();
            var recipeCount = recipeDbContext.Recipes.Count();
            //act && assert
            await Assert.ThrowsAnyAsync<ArgumentException>(async () => await recipeRepository.Add(RecipeSamples.NormalRecipe));

        }

        public void Dispose()
        {
            recipeDbContext.Database.EnsureDeleted();
            recipeDbContext.Dispose();
        }
    }
}
