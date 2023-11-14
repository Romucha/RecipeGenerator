using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    internal interface IIngredientFactory
    {
        IIngredient Create(string Name, string Description, Uri Link);
    }
}
