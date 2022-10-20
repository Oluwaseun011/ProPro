using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StudentsPage : ContentPage
    {
        StudentsViewModel _viewModel;

        public StudentsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new StudentsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}