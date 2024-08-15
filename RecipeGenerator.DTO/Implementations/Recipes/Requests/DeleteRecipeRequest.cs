using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.Recipes.Requests
{
    public record DeleteRecipeRequest : IDeleteRequest
    {
        public Guid Id { get; set; }
    }
}
