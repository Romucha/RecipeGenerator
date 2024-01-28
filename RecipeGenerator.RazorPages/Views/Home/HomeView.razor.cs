using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Home
{
    public partial class HomeView
    {
        [Inject]
        public HomeVM HomeVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            HomeVM.PropertyChanged += HomeVM_PropertyChanged;
            HomeVM.GetRecipesCommand.Execute(null);

            await base.OnInitializedAsync();
        }

        public void StateHasChangedPublic()
        {
            this.StateHasChanged();
        }

        private void HomeVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            this.StateHasChanged();
        }
    }
}
