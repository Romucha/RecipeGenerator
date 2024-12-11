namespace RecipeGenerator.DTO.Steps.Requests
{
    public record UpdateStepRequest
    {
        /// <summary>
        /// Step identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Counter.
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        /// List of photos.
        /// </summary>
        public List<byte[]>? Photos { get; set; } = new List<byte[]>();

        /// <summary>
        /// Identifier of the parent recipe.
        /// </summary>
        public int RecipeId { get; set; }
    }
}
