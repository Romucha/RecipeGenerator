using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Recipes
{
    public class RecipeFactory : IRecipeFactory
    {
        public async Task<Recipe> DefaultRecipe()
        {
            return await Task.FromResult<Recipe>(new Recipe()
            {
                Steps = new List<Step>(),
                Ingredients = new List<IIngredient>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Id = Guid.NewGuid(),
                Description = string.Empty,
                Name = string.Empty,
                CourseType = Course.Unknown
            });;
        }
    }
}
