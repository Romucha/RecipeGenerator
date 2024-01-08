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
                                                                                                               .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                                                                                                               .Options;
            recipeDbContext = new RecipeDbContext(configuration, ingredientgetter, dbContextOptions);

            recipeRepository = new RecipeRepository(recipeDbContext);
        }

        #region Get Recipe Tests
        [Fact]
        public async Task GetAllRecipes_Normal()
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

        [Fact]
        public async Task GetRecipeById_Normal()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();
            //act
            var recipe = await recipeRepository.GetById(RecipeSamples.NormalRecipes.FirstOrDefault().Id);
            //assert
            Assert.NotNull(recipe);
        }

        [Fact]
        public async Task GetRecipeById_IncorrectId()
        {
            //arrange
            await recipeDbContext.Recipes.AddRangeAsync(RecipeSamples.NormalRecipes);
            await recipeDbContext.SaveChangesAsync();

            var id = Guid.NewGuid();
            //act
            var recipe = await recipeRepository.GetById(id);
            //assert
            Assert.Null(recipe);
        }

        [Fact]
        public async Task GetRecipeById_EmptyDatabase()
        {
            //arrange
            var guid = RecipeSamples.NormalRecipe.Id;
            //act
            var recipe = await recipeRepository.GetById(guid);
            //assert
            Assert.Null(recipe);
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

        [Fact]
        public async Task AddRecipe_ExistingOne()
        {
            //arrange
            recipeDbContext.Recipes.Add(RecipeSamples.NormalRecipe);
            await recipeDbContext.SaveChangesAsync();
            var recipeCount = recipeDbContext.Recipes.Count();
            //act && assert
            await Assert.ThrowsAnyAsync<ArgumentException>(async () => await recipeRepository.Add(RecipeSamples.NormalRecipe));

        }
        #endregion

        #region Detele Recipe Tests

        #endregion

        #region Update Recipe Tests

        #endregion
    }
}
