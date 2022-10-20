using System;
using System.Collections.Generic;
using TestXam.ViewModels;
using TestXam.Views;
using Xamarin.Forms;

namespace TestXam
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(StudentDetailPage), typeof(StudentDetailPage));
            Routing.RegisterRoute(nameof(NewStudentPage), typeof(NewStudentPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
