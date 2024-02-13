using RecipeGenerator.API.Properties;
using RecipeGenerator.API.Properties.Ingredients;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    public static class IngredientTypeDisplayNameExtension
    {
        public static string ToDisplayName(this IngredientType ingredientType)
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager(typeof(IngredientTypeNames));

                ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                return resourceSet.Cast<DictionaryEntry>()
                                  .FirstOrDefault(c => c.Key.ToString() == $"{ingredientType}")
                                  .Value
                                  .ToString();
            }
            catch
            {
                return ingredientType.ToString();
            }
        }
    }
}
