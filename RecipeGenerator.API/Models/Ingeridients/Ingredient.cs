using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Ingeridients
{
    internal class Ingredient : IParametersFromSource<Ingredient>
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Link { get; set; }
        public IngredientType IngredientType { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public byte[] Image { get; set; }

        public void CopyFromSource(Ingredient source)
        {
            Name = source.Name;
            Description = source.Description;
            Link = source.Link;
            IngredientType = source.IngredientType;
            CreatedAt = source.CreatedAt;
            UpdatedAt = source.UpdatedAt;
            Image = source.Image;
        }
    }


}
