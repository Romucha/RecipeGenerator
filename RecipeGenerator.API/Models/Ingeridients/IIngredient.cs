using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    /*
        Vegetables
        Spices and Herbs
        Cereals and Pulses
        Meat
        Dairy Products
        Fruits
        Seafood
        Sugar and Sugar Products
        Nuts and Oilseeds
        Other Ingredients
     */
    public interface IIngredient
    {
        string Name { get; set; }

        string Description { get; set; }

        Uri Link { get; set; }

        IngredientType IngredientType { get; set; }

        byte[] Image { get; set; }
    }
}
