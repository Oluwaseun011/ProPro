using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using TestXam.Services;
using Xamarin.Forms;

namespace TestXam.ViewModels
{
    [QueryProperty(nameof(StudentId), nameof(StudentId))]
    public class StudentDetailViewModel : BaseViewModel
    {
        private Guid studentId;
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Guid StudentId
        {
            get
            {
                return studentId;
            }
            set
            {
                studentId = value;
                LoadStudentId(value);
            }
        }

        public async void LoadStudentId(Guid  studentId)
        {
            try
            {
                var student = await StudentStore.GetStudentAsync(studentId);
                Id = student.Id;
                FirstName = student.FirstName;
                LastName = student.LastName;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
