﻿using RecipeGenerator.DTO.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.AppliedIngredients.Responses
{
    public record GetAllAppliedIngredientsResponse : IGetAllResponse<IGetAllResponseItem>
    {
        public IEnumerable<IGetAllResponseItem> Items { get; set; } = default!;
    }
}
