using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using RecipeGenerator.API.Models.AppliedIngredients;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Steps;

namespace RecipeGenerator.API.Models.Recipes
{
    /// <summary>
    /// Contains basic information about recipe
    /// </summary>
    internal class Recipe : IParametersFromSource<Recipe>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Description { get; set; }

        public Course CourseType { get; set; }

        public List<Step> Steps { get; set; }

        public List<AppliedIngredient> Ingredients { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public TimeSpan Time { get; set; }

        public void CopyFromSource(Recipe source)
        {
            Name = source.Name;
            Image = source.Image;
            Description = source.Description;
            CreatedAt = source.CreatedAt;
            UpdatedAt = source.UpdatedAt;
            Steps = source.Steps;
            Ingredients = source.Ingredients;
        }
    }
}