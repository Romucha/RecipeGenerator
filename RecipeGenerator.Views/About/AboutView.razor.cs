using Microsoft.AspNetCore.Components;
using RecipeGenerator.ViewModels.About;

namespace RecipeGenerator.Views.About
{
    public partial class AboutView
    {
        [Inject]
        public AboutViewModel ViewModel { get; set; } = default!;
    }
}
