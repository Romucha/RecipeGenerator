using RecipeGenerator.DTO.Recipes;
using RecipeGenerator.DTO.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Ingredients
{
    public class GetApplicableIngredientDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Uri Link { get; set; }

        public int IngredientType { get; set; }

        public string Image { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
