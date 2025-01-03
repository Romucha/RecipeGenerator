using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record GetApplicableIngredientResponse : BaseGetResponse
    {
        /// <summary>
        /// Link to an internet page about the ingredient.
        /// </summary>
        public Uri Link { get; set; } = default!;

        /// <summary>
        /// Ingredient type.
        /// </summary>
        public int IngredientType { get; set; }

        /// <summary>
        /// Image of the ingredient.
        /// </summary>
        public byte[] Image { get; set; } = default!;

        /// <summary>
        /// Measurement type.
        /// </summary>
        public int MeasurementType { get; set; }
    }
}
