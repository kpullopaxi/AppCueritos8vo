using MOVIL_APP.Views.Administration;

namespace MOVIL_APP
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage =new NavigationPage(new Views.Public.Login());
       

        }
    }
}