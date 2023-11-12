using Microsoft.AspNetCore.Components;
using RecipeGenerator.App.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.App.Pages
{
    public partial class Home
    {
        [Inject]
        private MainVM mainVM { get; set; }
    }
}
