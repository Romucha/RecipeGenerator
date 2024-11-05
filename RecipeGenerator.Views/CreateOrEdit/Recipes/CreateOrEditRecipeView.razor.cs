using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Localization;
using RecipeGenerator.ViewModels.CreateOrEdit.Recipes;

namespace RecipeGenerator.Views.CreateOrEdit.Recipes
{
    public partial class CreateOrEditRecipeView
    {
        [Inject]
        public CreateOrEditRecipeViewModel ViewModel { get; set; } = default!;

        [Parameter]
        public Guid? RecipeId { get; set; }

        [Inject]
        public IStringLocalizer<CreateOrEditRecipeView> StringLocalizer { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            if (ViewModel != null)
            {
                ViewModel.PropertyChanged += (sender, e) => StateHasChanged();
                ViewModel.Steps.CollectionChanged += (sender, e) => StateHasChanged();
                ViewModel.ApplicableIngredients.CollectionChanged += (sender, e) => StateHasChanged();
                ViewModel.AppliedIngredients.CollectionChanged += (sender, e) => StateHasChanged();
                await ViewModel.InitializeAsync(RecipeId);
            }

            await base.OnInitializedAsync();
        }
    }
}
