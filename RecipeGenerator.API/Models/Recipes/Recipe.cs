using System.ComponentModel.DataAnnotations;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Steps;

namespace RecipeGenerator.API.Models.Recipes
{
    /// <summary>
    /// Contains basic information about recipe
    /// </summary>
    public class Recipe
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Course CourseType { get; set; }

        public List<Step> Steps { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}