using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Tests.Models.Recipes
{
    public class RecipeFactoryTests
    {
        [Fact]
        public async Task Create_Normal()
        {
            //arrange
            IRecipeFactory recipeFactory = new RecipeFactory();
            var defaultRecipe = new Recipe()
            {
                Name = string.Empty,
                Description = string.Empty,
                CourseType = Course.Unknown,
                Image = null,
                Steps = new List<Step>(),
                Ingredients = new List<Ingredient>(),
            };
            //act
            var recipe = await recipeFactory.DefaultRecipe();
            //assert
            assertRecipes(recipe, defaultRecipe);
        }

        private void assertRecipes(Recipe actualRecipe, Recipe expectedRecipe)
        {
            Assert.NotNull(actualRecipe);
            Assert.NotNull(expectedRecipe);

            Assert.Equal(expectedRecipe.Name, actualRecipe.Name);
            Assert.Equal(expectedRecipe.Description, actualRecipe.Description);
            Assert.Equal(expectedRecipe.CourseType, actualRecipe.CourseType);
            Assert.Equal(expectedRecipe.Image, actualRecipe.Image);
            Assert.Equal(expectedRecipe.Steps, actualRecipe.Steps);
            Assert.Equal(expectedRecipe.Ingredients, actualRecipe.Ingredients);
        }
    }
}
