using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.DTO.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.Recipes
{
    public class GetRecipeDTO : CreateRecipeDTO
    {
        public Guid Id { get; set; }
    }
}
