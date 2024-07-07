using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.AppliedIngredients.Requests
{
    public record DeleteAppliedIngredientRequest
    {
        public Guid Id { get; set; }
    }
}
