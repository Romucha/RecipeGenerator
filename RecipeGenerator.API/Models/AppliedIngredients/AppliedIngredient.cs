using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.API.Models.AppliedIngredients
{
    internal class AppliedIngredient
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public Guid Id { get; set; }

        [ForeignKey(nameof(Recipe))]
        public Guid RecipeId { get; set; }

        public Recipe Recipe { get; set; }

        [ForeignKey(nameof(Ingredient))]
        public Guid IngredientId { get; set; }

        public Ingredient Ingredient { get; set; }
    }
}
