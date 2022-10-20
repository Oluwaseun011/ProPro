using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using TestXam.Models;
using TestXam.Views;
using Xamarin.Forms;

namespace TestXam.ViewModels
{
    public class StudentsViewModel : BaseViewModel
    {
        private Student _selectedItem;

        public ObservableCollection<Student> Students { get; }
        public Command LoadStudentsCommand { get; }
        public Command AddStudentCommand { get; }
        public Command<Student> StudentTapped { get; }

        public StudentsViewModel()
        {
            Title = "Browse";
            Students = new ObservableCollection<Student>();
            LoadStudentsCommand = new Command(async () => await ExecuteLoadStudentsCommand());

            StudentTapped = new Command<Student>(OnStudentSelected);

            AddStudentCommand = new Command(OnAddStudent);
        }

        async Task ExecuteLoadStudentsCommand()
        {
            IsBusy = true;

            try
            {
                Students.Clear();
                var students = await StudentStore.GetStudentsAsync();
                foreach (var student in students)
                {
                    Students.Add(student);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedStudent = null;
        }

        public Student SelectedStudent
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnStudentSelected(value);
            }
        }

        private async void OnAddStudent(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewStudentPage));
        }

        async void OnStudentSelected(Student student)
        {
            if (student == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(StudentDetailPage)}?{nameof(StudentDetailViewModel.StudentId)}={student.Id}");

        }
    }
}

