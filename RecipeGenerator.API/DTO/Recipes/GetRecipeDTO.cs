using RecipeGenerator.API.DTO.AppliedIngredients;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.DTO.Steps;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.Recipes
{
    public class GetRecipeDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; } = default!;

        public string Description { get; set; }

        public Course CourseType { get; set; }

        public List<GetAppliedIngredientDTO> Ingredients { get; set; }

        public List<GetStepDTO> Steps { get; set; }

        public TimeSpan Time { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
