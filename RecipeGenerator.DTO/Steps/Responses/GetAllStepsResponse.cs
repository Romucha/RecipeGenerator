using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.Steps.Responses
{
    public record GetAllStepsResponse : BaseGetAllResponse
    {
        public IEnumerable<GetAllStepsResponseItem> Items { get; set; } = Enumerable.Empty<GetAllStepsResponseItem>();
    }
}
