using RecipeGenerator.DTO.Base.Requests;

namespace RecipeGenerator.DTO.Measurements.Requests
{
    public record UpdateMeasurementRequest : BaseUpdateRequest
    {
        /// <summary>
        /// Type of the measurement.
        /// </summary>
        public int? MeasurementType { get; set; }

        /// <summary>
        /// Determines if the measurement is base.
        /// </summary>
        public bool? IsBase { get; set; }

        /// <summary>
        /// Coefficient of conversion.
        /// </summary>
        public double? ConversionCoefficient { get; set; }
    }
}
