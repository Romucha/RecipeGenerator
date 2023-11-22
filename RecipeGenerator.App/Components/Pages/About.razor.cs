using Microsoft.AspNetCore.Components;
using RecipeGenerator.API.Database;
using RecipeGenerator.API.Models.Ingeridients;
using RecipeGenerator.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.Components.Pages
{
    public partial class About
    {
        [Inject]
        private AboutVM aboutVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await aboutVM.GetIngredientsCommand.ExecuteAsync(null);
        }
    }
}
