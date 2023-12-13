using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RecipeGenerator.API.Database;
using RecipeGenerator.RazorPages.ViewModels.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.Components.Pages
{
    public partial class Start
    {
        [Inject]
        public StartVM startVM { get; set; }

        protected override async Task OnInitializedAsync()
        {
            startVM.ResetRecipeCommand.Execute(null);
            await base.OnInitializedAsync();
        }

        public async Task RecipeSubmitted(EditContext editContext)
        {
            if (editContext.Validate())
            {
                try
                {
                    await startVM.AddRecipeCommand.ExecuteAsync(null);
                    startVM.ResetRecipeCommand.Execute(null);
                }
                catch (Exception ex) 
                {
                    
                }
            }
        }
    }
}
