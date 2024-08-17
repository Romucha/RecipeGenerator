using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.ApplicableIngredients.Requests
{
    public record DeleteApplicableIngredientRequest : IDeleteRequest
    {
        public Guid Id { get; set; }
    }
}
