using RecipeGenerator.DTO.Base.Responses;

namespace RecipeGenerator.DTO.AppliedIngredients.Responses
{
    public record UpdateAppliedIngredientResponse : BaseUpdateResponse
    {
        /// <summary>
        /// Identifier of a parent recipe.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        /// Identifier of a base ingredient.
        /// </summary>
        public int IngredientId { get; set; }

        /// <summary>
        /// Identifier of a measurement.
        /// </summary>
        public int MeasurementId { get; set; }

        /// <summary>
        /// Value of the measurement.
        /// </summary>
        public double MeasurementValue { get; set; }
    }
}
