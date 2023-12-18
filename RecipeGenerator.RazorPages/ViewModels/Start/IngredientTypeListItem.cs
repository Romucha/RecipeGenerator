using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Properties.Ingredients;
using RecipeGenerator.API.Properties.Recipes;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.ViewModels.Start
{
    public class IngredientTypeListItem
    {
        public string DisplayName { get; set; }

        public string Description { get; set; }

        public IngredientType Value { get; set; }

        public static IngredientTypeListItem FromIngredientType(IngredientType ingredientType)
        {
            var ingredientTypeItem = new IngredientTypeListItem();

            ResourceManager resourceManagerNames = new ResourceManager(typeof(IngredientTypeNames));
            ResourceSet resourceSetNames = resourceManagerNames.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            ResourceManager resourceManagerDescriptions = new ResourceManager(typeof(IngredientTypeDescriptions));
            ResourceSet resourceSetDescriptions = resourceManagerDescriptions.GetResourceSet(CultureInfo.CurrentUICulture, true, true);

            ingredientTypeItem.Value = ingredientType;
            ingredientTypeItem.DisplayName = resourceSetNames.GetString(ingredientType.ToString(), true);
            ingredientTypeItem.Description = resourceSetDescriptions.GetString(ingredientType.ToString(), true);

            return ingredientTypeItem;
        }
    }
}
