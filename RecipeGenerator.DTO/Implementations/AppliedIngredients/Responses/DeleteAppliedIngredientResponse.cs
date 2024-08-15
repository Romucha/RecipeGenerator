using RecipeGenerator.DTO.Interfaces.Responses;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses
{
    public record DeleteAppliedIngredientResponse : IDeleteResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
