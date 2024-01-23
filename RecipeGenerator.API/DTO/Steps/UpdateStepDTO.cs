using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.DTO.Steps
{
    public class UpdateStepDTO
    {
        public string Name { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }

        public List<byte[]> Photos { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid RecipeId { get; set; }
    }
}
