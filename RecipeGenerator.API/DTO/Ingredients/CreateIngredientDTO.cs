using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.DTO.Steps;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.Ingredients
{
    public class CreateIngredientDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Uri Link { get; set; }

        public IngredientType IngredientType { get; set; }

        public byte[] Image { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
