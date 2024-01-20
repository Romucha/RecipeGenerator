using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.RazorPages.ViewModels.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add.Ingredients
{
    public partial class IngredientListView
    {
        [CascadingParameter]
        public AddVM AddVM { get; set; }
    }
}
