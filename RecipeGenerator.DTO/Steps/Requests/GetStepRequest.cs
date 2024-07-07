using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Steps.Requests
{
    public record GetStepRequest
    {
        public Guid Id { get; set; }
    }
}
