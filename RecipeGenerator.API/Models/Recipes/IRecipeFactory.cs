﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Recipes
{
    public interface IRecipeFactory
    {
        Task<Recipe> DefaultRecipe();
    }
}
