using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Navigation
{
    public partial class NavigationButton
    {
        [Inject]
        private NavigationManager navigationManager { get; set; } 

        [Parameter]
        public string NavPath { get; set; }

        [Parameter]
        public string OiIcon { get; set; }

        [Parameter]
        public string OiTitle { get; set; }

        [Parameter]
        public bool IsBig { get; set; } = false;

        private string activeClass;

        private string getActiveClass() => navigationManager.Uri == new Uri(navigationManager.BaseUri + NavPath).OriginalString ? "btn btn-nav active" : "btn btn-nav";

        private void changeActiveClass()
        {
            activeClass = getActiveClass();
            StateHasChanged();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            activeClass = getActiveClass();
        }
    }
}
