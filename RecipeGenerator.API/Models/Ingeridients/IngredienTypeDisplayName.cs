using RecipeGenerator.API.Properties;
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
    public static class IngredienTypeDisplayNameExtension
    {
        public static string ToDisplayName(this IngredientType ingredientType)
        {
            try
            {
                ResourceManager resourceManager = new ResourceManager(typeof(Properties.Resources));

                ResourceSet resourceSet = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true);
                return resourceSet.Cast<DictionaryEntry>()
                                  .FirstOrDefault(c => c.Key.ToString() == $"{ingredientType}_TypeName")
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
