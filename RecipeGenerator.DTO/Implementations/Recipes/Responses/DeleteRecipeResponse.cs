using RecipeGenerator.DTO.Interfaces.Responses;

namespace RecipeGenerator.DTO.Implementations.Recipes.Responses
{
    public record DeleteRecipeResponse : IDeleteResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
