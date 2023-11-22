using System.ComponentModel.DataAnnotations;

namespace RecipeGenerator.API.Models
{
    /// <summary>
    /// Contains basic information about recipe
    /// </summary>
    public class Recipe
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public Course CourseType { get; set; }

        public IEnumerable<Step> Steps { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}