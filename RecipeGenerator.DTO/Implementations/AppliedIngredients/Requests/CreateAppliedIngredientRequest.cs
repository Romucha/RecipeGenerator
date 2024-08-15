using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests
{
    public record CreateAppliedIngredientRequest : ICreateRequest
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }
    }
}
