using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipeGenerator.Models
{
    public interface IRecipeGeneratorEntity
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        int Id { get; set; }

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
