using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Models
{
    public interface IRecipeGeneratorNamedModel : IRecipeGeneratorModel
    {
        /// <summary>
        /// Display name.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        string Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [Required(AllowEmptyStrings = true)]
        string Description { get; set; }
    }
}
