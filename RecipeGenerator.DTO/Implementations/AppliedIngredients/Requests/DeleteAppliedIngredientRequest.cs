using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests
{
    public record DeleteAppliedIngredientRequest : IDeleteRequest
    {
        public Guid Id { get; set; }
    }
}
