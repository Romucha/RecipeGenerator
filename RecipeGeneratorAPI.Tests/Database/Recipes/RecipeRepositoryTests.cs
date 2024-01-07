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

        #endregion

        #region Add Recipe Tests
        [Fact]
        public async Task AddRecipe_Normal()
        {
            //arrange
            List<Ingredient> ingredients = new List<Ingredient>()
            {
                new Ingredient()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Ingredient 1",
                    Description = "Test Ingredient Description 1",
                    Image = Properties.Resources.apple,
                    IngredientType = IngredientType.CerealsAndPulses
                },
                new Ingredient()
                {
                    Id = Guid.NewGuid(),
                    Name = "Test Ingredient 2",
                    Description = "Test Ingredient Description 2",
                    Image = Properties.Resources.apple,
                    IngredientType = IngredientType.CerealsAndPulses
                }
            };

            Recipe recipe = new Recipe()
            {
                Id = Guid.NewGuid(),
                Name = "Test Name",
                Description = "Test Description",
                CourseType = Course.Soup,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Image = Properties.Resources.apple,
                Steps = new List<Step>
                {
                    new Step()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Step Name 1",
                        Description = "Step Description 1",
                        Photos = new List<byte[]>()
                        {
                            Properties.Resources.apple,
                            Properties.Resources.apple,
                        },
                        Ingredients = ingredients,
                    },
                    new Step()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Step Name 2",
                        Description = "Step Description 2",
                        Photos = new List<byte[]>()
                        {
                            Properties.Resources.apple,
                            Properties.Resources.apple,
                        },
                        Ingredients = ingredients,
                    }
                },
                Ingredients = ingredients
            };
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task AddRecipe_Default()
        {
            //arrange
            IRecipeFactory factory = new RecipeFactory();
            Recipe recipe = await factory.DefaultRecipe();
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task AddRecipe_Empty()
        {
            //arrange
            Recipe recipe = new Recipe();
            //act
            await recipeRepository.Add(recipe);
            //assert
            Assert.NotNull(await recipeDbContext.Recipes.FindAsync(recipe.Id));
        }

        [Fact]
        public async Task AddRecipe_Null()
        {
            //arrange
            Recipe? recipe = null;
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
