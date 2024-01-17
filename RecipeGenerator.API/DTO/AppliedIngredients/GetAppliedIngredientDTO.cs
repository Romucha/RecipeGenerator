using RecipeGenerator.API.Models.AppliedIngredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.AppliedIngredients
{
    public class GetAppliedIngredientDTO : CreateAppliedIngredientDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
