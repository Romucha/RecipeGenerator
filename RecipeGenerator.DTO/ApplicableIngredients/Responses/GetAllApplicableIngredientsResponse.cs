using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record GetAllApplicableIngredientsResponse : BaseGetAllResponse
    {
        public IEnumerable<GetAllApplicableIngredientsResponseItem> Items { get; set; } = Enumerable.Empty<GetAllApplicableIngredientsResponseItem>();
    }
}
