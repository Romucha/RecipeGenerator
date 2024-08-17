using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.ApplicableIngredients.Requests
{
    public record GetApplicableIngredientRequest : IGetRequest
    {
        public Guid Id { get; set; }
    }
}
