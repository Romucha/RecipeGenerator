using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Steps.Responses
{
    public record GetAllStepsResponse
    {
        public IEnumerable<GetAllStepResponse> Items { get; set; } = default!;
    }
}
