using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.ApplicableIngredients.Responses
{
    public record DeleteApplicableIngredientResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
