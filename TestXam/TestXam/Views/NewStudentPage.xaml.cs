using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestXam.Models;
using TestXam.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TestXam.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewStudentPage : ContentPage
    {
        public Student Student { get; set; }

        public NewStudentPage()
        {
            InitializeComponent();
            BindingContext = new NewStudentViewModel();
        }
    }
}