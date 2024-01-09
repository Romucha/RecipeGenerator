using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.DTO.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.Ingredients
{
    public class GetIngredientDTO : CreateIngredientDTO
    {
        public Guid Id { get; set; }
    }
}
