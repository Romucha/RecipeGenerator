using RecipeGenerator.Models.Ingredients;
using RecipeGenerator.Models.Recipes;
using RecipeGenerator.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Functionalities.Factories.Recipes
{
    internal class RecipeFactory
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
            }); ;
        }
    }
}
