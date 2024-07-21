using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlTypes;

namespace RecipeGenerator.Models
{
    public interface IRecipeGeneratorEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        Guid Id { get; set; }

        /// <summary>
        /// Date of creation.
        /// </summary>
        DateTime CreatedAt { get; set; }

        /// <summary>
        /// Date of last update.
        /// </summary>
        DateTime UpdatedAt { get; set; }
  
        /// <summary>
        /// Display name.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        string Description { get; set; }
    }
}
