﻿using RecipeGenerator.DTO.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses
{
    public record DeleteAppliedIngredientResponse : IDeleteResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
