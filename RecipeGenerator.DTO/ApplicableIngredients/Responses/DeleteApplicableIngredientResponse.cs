namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record DeleteApplicableIngredientResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
