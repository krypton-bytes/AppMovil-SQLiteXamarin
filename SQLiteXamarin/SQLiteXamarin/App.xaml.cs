using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteXamarin
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Agregar la página de inicio dentro de una NavigationPage
            MainPage = new NavigationPage(new PaginaInicio());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
