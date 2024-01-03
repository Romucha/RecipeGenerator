using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Explore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Explore
{
    public partial class ExploreView
    {
        [Parameter]
        public ExploreVM ExploreVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ExploreVM.GetIngredientsCommand.Execute(null);
            await base.OnInitializedAsync();
        }
    }
}
