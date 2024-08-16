namespace RecipeGenerator.DTO.Implementations.Steps.Requests
{
    public record GetAllStepsRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string? Filter { get; set; }
    }
}
