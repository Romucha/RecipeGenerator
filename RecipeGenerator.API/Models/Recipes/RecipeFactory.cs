using RecipeGenerator.API.Models.AppliedIngredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Recipes
{
    internal class RecipeFactory : IRecipeFactory
    {
        public async Task<Recipe> Create()
        {
            return await Task.FromResult<Recipe>(new Recipe()
            {
                Steps = new List<Step>(),
                Ingredients = new List<AppliedIngredient>(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                Description = string.Empty,
                Name = string.Empty,
                CourseType = Course.Unknown
            });;
        }
    }
}
