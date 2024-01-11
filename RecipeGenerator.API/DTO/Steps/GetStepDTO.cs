using RecipeGenerator.API.DTO.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.Steps
{
    public class GetStepDTO : CreateStepDTO
    {
        public Guid Id { get; set; }
    }
}
