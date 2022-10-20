using System;
using TestXam.Services;
using TestXam.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXam
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
