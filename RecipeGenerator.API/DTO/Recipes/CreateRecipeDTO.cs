using RecipeGenerator.API.DTO.AppliedIngredients;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.DTO.Steps;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.Recipes
{
    public class CreateRecipeDTO
    {
        public string Name { get; set; }

        public byte[] Image { get; set; } = default!;

        public string Description { get; set; }

        public Course CourseType { get; set; }

        public List<CreateAppliedIngredientDTO> Ingredients { get; set; }

        public List<CreateStepDTO> Steps { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
