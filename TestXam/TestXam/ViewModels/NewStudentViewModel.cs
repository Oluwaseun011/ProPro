using StudentAppTesting.Enum;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TestXam.Models;
using Xamarin.Forms;

namespace TestXam.ViewModels
{
    public class NewStudentViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Comment { get; set; }


        public NewStudentViewModel()
        {
            SaveCommand = new Command(OnSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged +=
                (_, __) => SaveCommand.ChangeCanExecute();
        }

       /* private bool ValidateSave()
        {
            return !string.IsNullOrWhiteSpace(FirstName)
                && !string.IsNullOrWhiteSpace(LastName);
        }
*/

        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSave()
        {
            Student newStudent = new Student()
            {
                FirstName = FirstName,
                LastName = LastName,
                Gender = Gender,
                DateOfBirth = DateOfBirth,
                Comment = Comment
            };

            await StudentStore.AddStudentAsync(newStudent);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
