using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.DTO.Recipes;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.RazorPages.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Home.Tables
{
    public partial class RecipeTable
    {
        [Parameter]
        public HomeVM HomeVM { get; set; }
    }
}
