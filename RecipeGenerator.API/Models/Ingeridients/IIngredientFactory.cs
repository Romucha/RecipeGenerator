using RecipeGenerator.API.DTO.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    internal interface IIngredientFactory
    {
        Ingredient Create(string name, string description, Uri link, string image, IngredientType ingredientType);

        Ingredient CreateFromDTO(CreateIngredientDTO createIngredientDTO);
    }
}
