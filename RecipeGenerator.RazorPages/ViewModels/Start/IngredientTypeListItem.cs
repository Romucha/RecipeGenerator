using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Start
{
    public class IngredientTypeListItem
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public IngredientType Value { get; set; }

        public IngredientTypeListItem FromIngredientType()
        {
            return new IngredientTypeListItem();
        }
    }
}
