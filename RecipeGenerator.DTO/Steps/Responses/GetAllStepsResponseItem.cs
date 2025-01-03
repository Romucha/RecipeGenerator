using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.Steps.Responses
{
    public record GetAllStepsResponseItem : BaseGetAllResponseItem
    {
        public int Index { get; set; }
    }
}
