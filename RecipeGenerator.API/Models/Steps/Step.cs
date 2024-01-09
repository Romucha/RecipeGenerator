using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.Steps
{
    internal class Step
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<byte[]> Photos { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }
        public Recipe Recipe { get; set; }

        public void AddIngredient(Ingredient ingredient)
        {
            if (Ingredients is null)
                return;
            if (Ingredients?.Contains(ingredient) == true)
                return;

            Ingredients.Add(ingredient);
            Description = $"{Description} {ingredient.Name.ToLower()}";
        }

        public void AddPhoto()
        {
            throw new NotImplementedException();
        }
    }
}
