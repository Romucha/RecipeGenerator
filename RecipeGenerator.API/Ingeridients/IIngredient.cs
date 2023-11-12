using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Ingeridients
{
    /*
        Accrording to the internet:
        Spices
        Dairy
        Eggs
        Fats
        Flour
        Fruits
        Meat
        Nuts
        Salt
        Sauces
        Seafood
        Sugar
        Food additive
        Oils
        Soy sauce
        Vinegar
     */
    public interface IIngredient
    {
        string Name { get; set; }

        string Description { get; set; }

        Uri Link { get; set; }
    }
}
