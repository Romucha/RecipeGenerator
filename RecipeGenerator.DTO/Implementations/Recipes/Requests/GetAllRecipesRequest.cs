﻿using RecipeGenerator.DTO.Interfaces.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.Recipes.Requests
{
    public record GetAllRecipesRequest : IGetAllRequest
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public string Filter { get; set; } = default!;
    }
}