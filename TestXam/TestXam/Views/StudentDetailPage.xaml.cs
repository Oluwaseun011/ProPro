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
    public partial class StudentDetailPage : ContentPage
    {
        public StudentDetailPage()
        {
            InitializeComponent();
            BindingContext = new StudentDetailViewModel();
        }
    }
}