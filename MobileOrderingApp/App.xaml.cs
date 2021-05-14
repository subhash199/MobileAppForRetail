using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MobileOrderingApp.Services;
using MobileOrderingApp.Views;

namespace MobileOrderingApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            //MainPage = new AppShell();
            //MainPage = new NavigationPage( new LoginPage());
            MainPage = new NavigationPage(new ItemsPage());
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
