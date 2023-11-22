using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    public class IngredientFactory : IIngredientFactory
    {
        public IIngredient Create(string name, string description, Uri link, byte[] image, IngredientType ingredientType)
        {
            return new Ingredient()
            { 
                Id = Guid.NewGuid(),
                Name = name, 
                Description = description, 
                Link = link, 
                IngredientType = ingredientType,
                Image = image
            };
        }
    }
}
