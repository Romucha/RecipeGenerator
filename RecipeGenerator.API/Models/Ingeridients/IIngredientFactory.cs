using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    public interface IIngredientFactory
    {
        IIngredient Create(string name, string description, Uri link, byte[] image, IngredientType ingredientType);
    }
}
