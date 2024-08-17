using RecipeGenerator.DTO.Interfaces.Responses;

namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record GetAllApplicableIngredientsResponse : IGetAllResponse<IGetAllResponseItem>
    {
        public IEnumerable<IGetAllResponseItem> Items { get; set; } = default!;
    }
}
