using RecipeGenerator.DTO.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Requests
{
    public record CreateAppliedIngredientRequest : ICreateRequest
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }
    }
}
