using RecipeGenerator.DTO.Recipes.Responses;
using RecipeGenerator.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.Functionalities.Writers
{
    public interface IRecipeWriter
    {
        public void Write(GetRecipeResponse recipe);
    }
}
