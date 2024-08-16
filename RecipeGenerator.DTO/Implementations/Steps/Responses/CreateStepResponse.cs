using RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses;

namespace RecipeGenerator.DTO.Implementations.Steps.Responses
{
    public record CreateStepResponse
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of the last update.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Description.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Index.
        /// </summary>
        public int Index { get; set; }

        /// <summary>
        /// Photos.
        /// </summary>
        public List<byte[]> Photos { get; set; } = [];

        /// <summary>
        /// Recipe identifier.
        /// </summary>
        public Guid RecipeId { get; set; }
    }
}
