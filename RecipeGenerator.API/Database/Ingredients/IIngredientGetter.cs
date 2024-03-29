﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.API.DTO.Ingredients;
using RecipeGenerator.API.Models.Ingeridients;

namespace RecipeGenerator.API.Database.Ingredients
{
    public interface IIngredientGetter
    {
        IEnumerable<GetIngredientDTO> Get();
    }
}
