using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.Recipes.Responses
{
    public record GetAllRecipesResponse
    {
        public IEnumerable<GetAllRecipeResponse> Items { get; set; } = default!;
    }
}
