using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests
{
    public record GetApplicableIngredientRequest : IGetRequest
    {
        public Guid Id { get; set; }
    }
}
