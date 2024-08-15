namespace RecipeGenerator.DTO.Interfaces.Responses
{
    public interface IGetAllResponseItem
    {
        Guid Id { get; }

        public string Name { get; }

        public string Description { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }
    }
}
