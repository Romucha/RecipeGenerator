using RecipeGenerator.MVVM.Views.Navigation;

namespace RecipeGenerator.App
{
    public partial class App : Application
    {
        public App(NavigationTabbedPage shell)
        {
            InitializeComponent();

            MainPage = shell;
        }
    }
}
