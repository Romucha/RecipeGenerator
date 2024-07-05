using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Models
{
    public interface IRecipeGeneratorModel
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        Guid Id { get; set; }
    }
}
