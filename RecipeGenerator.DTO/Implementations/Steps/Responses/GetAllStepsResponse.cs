using RecipeGenerator.DTO.Interfaces.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Implementations.Steps.Responses
{
    public record GetAllStepsResponse : IGetAllResponse<GetAllStepResponse>
    {
        public IEnumerable<GetAllStepResponse> Items { get; set; } = default!;
    }
}
