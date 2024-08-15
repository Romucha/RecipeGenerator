using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.Recipes.Requests
{
    public record GetRecipeRequest : IGetRequest
    {
        public Guid Id { get; set; }
    }
}
