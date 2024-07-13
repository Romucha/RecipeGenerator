using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.DTO.Interfaces.Requests;

namespace RecipeGenerator.DTO.Implementations.Steps.Requests
{
    public record UpdateStepRequest : IUpdateRequest
    {
        /// <inheritdoc/>
        public Guid Id { get; set; }

        /// <summary>
        /// Display name.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Counter.
        /// </summary>
        public int? Index { get; set; }

        /// <summary>
        /// List of photos.
        /// </summary>
        public List<string>? Photos { get; set; }

        /// <summary>
        /// Id of parent recipe.
        /// </summary>
        public Guid? RecipeId { get; set; }
    }
}
