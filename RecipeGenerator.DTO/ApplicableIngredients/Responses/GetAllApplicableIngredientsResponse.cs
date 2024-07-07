using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record GetAllApplicableIngredientsResponse
    {
        public IEnumerable<GetAllApplicableIngredientResponse> Items { get; set; } = default!;
    }
}
