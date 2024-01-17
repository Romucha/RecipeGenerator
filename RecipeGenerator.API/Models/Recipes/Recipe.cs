using System.ComponentModel.DataAnnotations;
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
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public byte[] Image { get; set; }

        public string Description { get; set; }

        public Course CourseType { get; set; }

        public List<Step> Steps { get; set; }

        public List<AppliedIngredient> Ingredients { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public void CopyFromSource(Recipe source)
        {
            Name = source.Name;
            Image = source.Image;
            Description = source.Description;
            Steps.Clear();
            Steps.AddRange(source.Steps);
            Ingredients.Clear();
            Ingredients.AddRange(source.Ingredients);
            CreatedAt = source.CreatedAt;
            UpdatedAt = source.UpdatedAt;
        }
    }
}