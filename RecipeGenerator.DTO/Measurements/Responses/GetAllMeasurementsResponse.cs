using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.Measurements.Responses
{
    public record GetAllMeasurementsResponse : BaseGetAllResponse
    {
        public IEnumerable<GetAllMeasurementsResponseItem> Items { get; set; } = Enumerable.Empty<GetAllMeasurementsResponseItem>();
    }
}
