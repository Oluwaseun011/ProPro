using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using TestXam.Models;

namespace TestXam.Services
{
    public interface IDataStore<T>
    {
        Task<ObservableCollection<T>> GetStudentsAsync();
        Task<T> GetStudentAsync(Guid id);
        Task<bool> UpdateStudentAsync(T student);
        Task<bool> DeleteStudentAsync(Guid id);
        Task<bool> AddStudentAsync(T student);

    }
}
