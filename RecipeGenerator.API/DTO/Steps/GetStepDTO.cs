using RecipeGenerator.API.DTO.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.Steps
{
    public class GetStepDTO
    {
        public Guid Id { get; set; }

        public ICollection<GetIngredientDTO> Ingredients { get; set; } = default!;
    }
}
