namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record DeleteApplicableIngredientResponse
    {
        public int Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
