using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Add;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add
{
    public partial class AddView
    {
        [Inject]
        public AddVM AddVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            AddVM.PropertyChanged += AddVM_PropertyChanged;

            AddVM.ResetRecipeCommand.Execute(null);
            AddVM.GetCourseListCommand.Execute(null);
            AddVM.GetIngredientTypesListCommand.Execute(null);
            AddVM.SelectedIngredientType = default;

            await base.OnInitializedAsync();
        }

        private void AddVM_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.StateHasChanged();
        }

        public async Task RecipeSubmitted(EditContext editContext)
        {
            if (editContext.Validate())
            {
                try
                {
                    await AddVM.SaveRecipeCommand.ExecuteAsync(null);
                    AddVM.ResetRecipeCommand.Execute(null);
                }
                catch (Exception ex)
                {

                }
            }
        }
    }
}
