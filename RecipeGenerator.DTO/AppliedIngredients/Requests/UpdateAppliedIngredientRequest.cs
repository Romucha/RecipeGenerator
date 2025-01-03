using RecipeGenerator.DTO.Base.Requests;

namespace RecipeGenerator.DTO.AppliedIngredients.Requests
{
    public record UpdateAppliedIngredientRequest : BaseUpdateRequest
    {
        /// <summary>
        /// Identifier of a parent recipe.
        /// </summary>
        public int? RecipeId { get; set; }

        /// <summary>
        /// Identifier of a base ingredient.
        /// </summary>
        public int? IngredientId { get; set; }

        /// <summary>
        /// Identifier of a measurement.
        /// </summary>
        public int? MeasurementId { get; set; }

        /// <summary>
        /// Value of the measurement.
        /// </summary>
        public double? MeasurementValue { get; set; }
    }
}
