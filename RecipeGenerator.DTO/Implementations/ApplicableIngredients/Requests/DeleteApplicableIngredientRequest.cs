using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.ApplicableIngredients.Requests
{
    public record DeleteApplicableIngredientRequest : IDeleteRequest
    {
        public Guid Id { get; set; }
    }
}
