using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Interfaces.Responses
{
    public interface IUpdateResponse
    {
        Guid Id { get; }

        public DateTime CreatedAt { get; }

        public DateTime UpdatedAt { get; }
    }
}
