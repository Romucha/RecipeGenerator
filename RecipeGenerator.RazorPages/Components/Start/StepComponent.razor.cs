using BlazorContextMenu;
using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.API.Models.Steps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Components.Start
{
    public partial class StepComponent
    {
        [Parameter]
        public IEnumerable<Ingredient> SelectedIngredients { get; set; }

        [Parameter]
        public Step Step { get; set; }

        private void AddIngredient(ItemClickEventArgs e)
        {
            //Step.Ingredients.Append(ingredient);
        }
    }
}
