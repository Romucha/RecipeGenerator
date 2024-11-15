using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Models.Measurements
{
    /// <summary>
    /// Type of a measurement.
    /// </summary>
    public enum MeasurementType
    {
        /// <summary>
        /// Undefined one.
        /// </summary>
        None = 0,
        /// <summary>
        /// For liquids (water, milk etc.).
        /// </summary>
        Liquid,
        /// <summary>
        /// For powder like substances (sugar, salt).
        /// </summary>
        Powder,
        /// <summary>
        /// For pieces of ingredients (whole carrots, cabbages etc.).
        /// </summary>
        Solid,
    }
}
