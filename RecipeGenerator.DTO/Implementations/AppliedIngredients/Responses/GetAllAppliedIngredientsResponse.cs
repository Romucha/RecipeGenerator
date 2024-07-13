using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses
{
    public record GetAllAppliedIngredientsResponse
    {
        public IEnumerable<GetAllAppliedIngredientResponse> Items { get; set; } = default!;
    }
}
