using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.Steps.Requests
{
    public record DeleteStepRequest
    {
        public Guid Id { get; set; }
    }
}
