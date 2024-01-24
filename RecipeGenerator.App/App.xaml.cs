using RecipeGenerator.MVVM.Views.Navigation;

namespace RecipeGenerator.App
{
    public partial class App : Application
    {
        public App(NavigationPanelView shell)
        {
            InitializeComponent();

            MainPage = shell;
        }
    }
}
