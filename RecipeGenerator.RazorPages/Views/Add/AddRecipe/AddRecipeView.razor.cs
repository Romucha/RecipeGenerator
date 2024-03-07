using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RecipeGenerator.RazorPages.ViewModels.Add.AddRecipe;

namespace RecipeGenerator.RazorPages.Views.Add.AddRecipe
{
    public partial class AddRecipeView
    {
        [Inject]
        public AddRecipeVM AddVM { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AddVM.PropertyChanged += async (sender, e) => await InvokeAsync(StateHasChanged);

            AddVM.ResetRecipeCommand.Execute(null);
            AddVM.GetCourseListCommand.Execute(null);
            AddVM.GetIngredientTypesListCommand.Execute(null);
            AddVM.SelectedIngredientType = default;

            await base.OnInitializedAsync();
        }

        public async Task RecipeSubmitted(EditContext editContext)
        {
            if (editContext.Validate())
            {
                try
                {
                    await AddVM.SaveRecipeCommand.ExecuteAsync(null);
                    AddVM.ResetRecipeCommand.Execute(null);
                    NavigationManager.NavigateTo("/");
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
