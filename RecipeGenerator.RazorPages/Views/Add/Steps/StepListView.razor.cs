using Microsoft.AspNetCore.Components;
using RecipeGenerator.RazorPages.ViewModels.Add;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.RazorPages.Views.Add.Steps
{
    public partial class StepListView
    {
        [CascadingParameter]
        public AddVM AddVM { get; set; }
    }
}
