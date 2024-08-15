using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests
{
    public record GetAppliedIngredientRequest : IGetRequest
    {
        public Guid Id { get; set; }
    }
}
