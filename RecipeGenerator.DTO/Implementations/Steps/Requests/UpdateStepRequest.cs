namespace RecipeGenerator.DTO.Implementations.Steps.Requests
{
    public record UpdateStepRequest
    {
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
        public List<byte[]>? Photos { get; set; }

        /// <summary>
        /// Id of parent recipe.
        /// </summary>
        public Guid? RecipeId { get; set; }
    }
}
