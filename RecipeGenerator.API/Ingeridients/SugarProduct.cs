﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Ingeridients
{
    public class SugarProduct : IIngredient
    {
        public string Name
        {
            get; set;
        }
        public string Description
        {
            get; set;
        }
        public Uri Link
        {
            get; set;
        }
    }
}
