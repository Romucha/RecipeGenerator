using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeGenerator.ViewModels.Main
{
    public class ProgressViewModel : ObservableObject
    {
        private bool inProgress = false;
        public bool InProgress
        {
            get => inProgress;
            set => SetProperty(ref inProgress, value);
        }
    }
}
