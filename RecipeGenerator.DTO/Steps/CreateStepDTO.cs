using RecipeGenerator.DTO.Ingredients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.DTO.Steps
{
    public class CreateStepDTO
    {
        public string Name { get; set; }

        public int Index { get; set; }

        public string Description { get; set; }

        public List<string> Photos { get; set; } = default!;

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid RecipeId { get; set; }
    }
}
