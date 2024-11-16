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
    [Flags]
    public enum MeasurementType
    {
        /// <summary>
        /// Undefined one.
        /// </summary>
        None = 0,
        /// <summary>
        /// For liquids (water, milk etc.).
        /// </summary>
        Liquid = 4,
        /// <summary>
        /// For powder like substances (sugar, salt).
        /// </summary>
        Powder = 16,
        /// <summary>
        /// For pieces of ingredients (whole carrots, cabbages etc.).
        /// </summary>
        Solid = 64,
    }
}
