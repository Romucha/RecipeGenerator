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
        None = 0,
        Weight = 2,
        Volume = 4,
        Amount = 8,
        Spoon = 16,
    }
}
