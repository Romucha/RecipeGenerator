using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    public class Ingredient : IIngredient
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }
        public IngredientType IngredientType { get; set; }
        public byte[] Image { get; set; }
    }
}
