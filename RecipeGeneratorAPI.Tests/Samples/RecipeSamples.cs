using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGeneratorAPI.Tests.Samples
{
    internal static class RecipeSamples
    {
        public static Recipe NormalRecipe { get; }

        public static Recipe DefaultRecipe { get; }

        public static Recipe EmptyRecipe { get; }

        public static Recipe NullRecipe { get; }

        static RecipeSamples()
        {
            NormalRecipe = new Recipe()
            {
                Id = Guid.NewGuid(),
                Name = "Test Name",
                Description = "Test Description",
                CourseType = Course.Soup,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Image = Properties.Resources.apple,
                Steps = StepSamples.NormalSteps,
                Ingredients = IngredientSamples.NormalIngredients
            };

            IRecipeFactory recipeFactory = new RecipeFactory();
            DefaultRecipe = recipeFactory.DefaultRecipe().Result;

            EmptyRecipe = new Recipe();

            NullRecipe = null;
        }
    }
}
