namespace RecipeGenerator.DTO.Steps.Responses
{
    public record GetAllStepsResponse
    {
        public int TotalCount { get; set; }

        public IEnumerable<GetAllStepsResponseItem> Items { get; set; } = Enumerable.Empty<GetAllStepsResponseItem>();
    }
}
