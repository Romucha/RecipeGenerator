using RecipeGenerator.DTO.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.ApplicableIngredients.Responses
{
    public record GetAllApplicableIngredientsResponse : IGetAllResponse
    {
        public IEnumerable<IGetAllResponseItem> Items { get; set; } = default!;
    }
}
