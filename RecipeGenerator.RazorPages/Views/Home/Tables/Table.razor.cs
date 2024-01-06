using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Models.Recipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Home.Tables
{
    public partial class Table
    {
        [Parameter]
        public IEnumerable<Recipe> Recipes { get; set; }
    }
}
