﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.ApplicableIngredients.Requests
{
    public record GetApplicableIngredientRequest
    {
        public Guid Id { get; set; }
    }
}
