using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Recipes.Requests
{
    public record DeleteRecipeRequest
    {
        public Guid Id { get; set; }
    }
}
