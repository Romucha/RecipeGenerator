using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Start.Save
{
    public partial class SaveView
    {
        [CascadingParameter]
        public StartVM StartVM { get; set; }
    }
}
