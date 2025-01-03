using RecipeGenerator.DTO.Base.Requests;

namespace RecipeGenerator.DTO.AppliedIngredients.Requests
{
    public record CreateAppliedIngredientRequest : BaseCreateRequest
    {
        public int RecipeId { get; set; }

        public int IngredientId { get; set; }
    }
}
