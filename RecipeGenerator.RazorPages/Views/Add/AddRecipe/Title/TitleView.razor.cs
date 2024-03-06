using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using RecipeGenerator.API.Models.Recipes;
using RecipeGenerator.RazorPages.ViewModels.Add.AddRecipe;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add.AddRecipe.Title
{
    public partial class TitleView
    {
        [CascadingParameter]
        public AddRecipeVM AddVM { get; set; }

        private string imagePath = "";

        private async Task AddPhoto(InputFileChangeEventArgs e)
        {
            try
            {
                var filedir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot", "images", "recipes", $"{DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss")}");
                if (!Directory.Exists(filedir))
                {
                    Directory.CreateDirectory(filedir);
                }
                var path = Path.Combine(filedir, e.File.Name);
                await using FileStream fs = new(path, FileMode.Create);
                await e.File.OpenReadStream().CopyToAsync(fs);
                imagePath = path.Replace(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "wwwroot"), "");
            }
            catch (Exception ex) 
            {

            }
        }
    }
}
