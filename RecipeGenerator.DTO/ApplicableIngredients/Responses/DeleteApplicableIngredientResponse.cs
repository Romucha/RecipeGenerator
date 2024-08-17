using RecipeGenerator.DTO.Interfaces.Responses;

namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record DeleteApplicableIngredientResponse : IDeleteResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
