using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.AppliedIngredients
{
    public class UpdateAppliedIngredientDTO
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }
    }
}
