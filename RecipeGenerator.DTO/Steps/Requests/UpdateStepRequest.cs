namespace RecipeGenerator.DTO.Steps.Requests
{
    public record UpdateStepRequest
    {
        /// <summary>
        /// Step identifier.
        /// </summary>
        public Guid Id { get; set; }

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
    }
}
