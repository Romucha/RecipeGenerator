﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Interfaces.Requests
{
    public interface IDeleteRequest
    {
        Guid Id { get; set; }
    }
}