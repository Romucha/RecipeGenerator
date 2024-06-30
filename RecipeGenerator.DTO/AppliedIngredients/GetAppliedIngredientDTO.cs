using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.AppliedIngredients
{
    public class GetAppliedIngredientDTO
    {
        public Guid RecipeId { get; set; }

        public Guid IngredientId { get; set; }
    }
}
