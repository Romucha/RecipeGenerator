using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Database.Recipes;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Home.Tables
{
    public partial class TableItem
    {
        [Inject]
        private IRecipeRepository recipeRepository { get; set; }
    
        [Parameter]
        public Recipe Recipe { get; set; }

        private async Task deleteRecipe()
        {
            await recipeRepository.Delete(Recipe);
            this.StateHasChanged();
        }
    }
}
