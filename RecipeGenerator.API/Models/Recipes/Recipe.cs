using System.ComponentModel.DataAnnotations;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Steps;

namespace RecipeGenerator.API.Models.Recipes
{
    /// <summary>
    /// Contains basic information about recipe
    /// </summary>
    internal class Recipe
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public Course CourseType { get; set; }

        public IEnumerable<Step> Steps { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}