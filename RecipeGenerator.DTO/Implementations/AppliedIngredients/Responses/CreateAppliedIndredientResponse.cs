using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.DTO.Interfaces.Responses;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses
{
    public record CreateAppliedIndredientResponse : ICreateResponse
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Name of the source ingredient.
        /// </summary>
        public string Name { get; set; } = default!;

        /// <summary>
        /// Description of the source ingredient.
        /// </summary>
        public string Description { get; set; } = default!;

        /// <summary>
        /// Identifier of a parent recipe.
        /// </summary>
        public Guid RecipeId { get; set; }

        /// <summary>
        /// Identifier of a base ingredient.
        /// </summary>
        public Guid IngredientId { get; set; }
    }
}
