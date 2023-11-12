namespace RecipeGenerator.API
{
    /// <summary>
    /// Contains basic information about recipe
    /// </summary>
    public class Recipe
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public Course CourseType { get; set; }

        public IEnumerable<Step> Steps { get; set; }
    }
}