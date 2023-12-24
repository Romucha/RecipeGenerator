﻿using RecipeGenerator.API.Models.Ingeridients;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Steps
{
    public class Step
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<byte[]> Photos { get; set; }

        public IEnumerable<Ingredient> Ingredients { get; set; }
    }
}
