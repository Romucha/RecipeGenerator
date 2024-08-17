namespace RecipeGenerator.DTO.Steps.Responses
{
    public record GetAllStepsResponse
    {
        public int TotalCount { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public IEnumerable<GetAllStepsResponseItem> Items { get; set; } = Enumerable.Empty<GetAllStepssResponseItem>();
    }
}
