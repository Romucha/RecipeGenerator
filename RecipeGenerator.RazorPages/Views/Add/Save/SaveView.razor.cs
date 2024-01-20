using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add.Save
{
    public partial class SaveView
    {
        [CascadingParameter]
        public AddVM AddVM { get; set; }
    }
}
