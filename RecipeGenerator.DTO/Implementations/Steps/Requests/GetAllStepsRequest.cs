using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.Steps.Requests
{
    public record GetAllStepsRequest : IGetAllRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; } = default!;
    }
}
