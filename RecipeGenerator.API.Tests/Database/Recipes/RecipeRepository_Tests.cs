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
using AutoMapper;
using RecipeGenerator.API.Mapping;
using RecipeGenerator.API.Tests.Samples;
using RecipeGenerator.API.Models.AppliedIngredients;

namespace RecipeGenerator.API.Tests.Database.Recipes
{
    public partial class RecipeRepository_Tests : IDisposable
    {
        private readonly IRecipeRepository recipeRepository;

        private readonly RecipeDbContext recipeDbContext;

        private readonly IMapper mapper;

        public RecipeRepository_Tests()
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

            recipeRepository = new RecipeRepository(recipeDbContext, mapper);

            RecipeSamples.NormalRecipe.Ingredients = new List<AppliedIngredient>(recipeDbContext.Ingredients
                                                                    .Take(5)
                                                                    .Select(c => new AppliedIngredient()
                                                                    {
                                                                        IngredientId = c.Id,
                                                                        Ingredient = c,
                                                                        IngredientState = IngredientState.None,
                                                                    }));
            RecipeSamples.NormalRecipes.ForEach(c => c.Ingredients = new List<AppliedIngredient>(recipeDbContext.Ingredients
                                                                    .Take(10)
                                                                    .Select(c => new AppliedIngredient()
                                                                    {
                                                                        IngredientId = c.Id,
                                                                        Ingredient = c,
                                                                        IngredientState = IngredientState.None,
                                                                    })));
        }

        public void Dispose()
        {
            recipeDbContext.Database.EnsureDeleted();
            recipeDbContext.Dispose();
        }

    }
}
