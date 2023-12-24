using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RecipeGenerator.RazorPages.ViewModels.Start;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Components.Start
{
    public partial class StartComponent
    {
        [Parameter]
        public StartVM StartVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            StartVM.PropertyChanged += StartVM_PropertyChanged;

            StartVM.ResetRecipeCommand.Execute(null);
            StartVM.GetCourseListCommand.Execute(null);
            StartVM.GetIngredientTypesListCommand.Execute(null);
            StartVM.SelectedIngredientType = default;

            await base.OnInitializedAsync();
        }

        private void StartVM_PropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            this.StateHasChanged();
        }

        public async Task RecipeSubmitted(EditContext editContext)
        {
            if (editContext.Validate())
            {
                try
                {
                    await StartVM.SaveRecipeCommand.ExecuteAsync(null);
                    StartVM.ResetRecipeCommand.Execute(null);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
