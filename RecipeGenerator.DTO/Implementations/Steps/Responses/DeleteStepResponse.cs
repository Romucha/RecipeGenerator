using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.Steps.Responses
{
    public record DeleteStepResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = default!;
    }
}
