using StudentAppTesting.Enum;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace TestXam.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Comment { get; set; }
    }
}
