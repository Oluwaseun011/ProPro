using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestXam.Models;

namespace TestXam.Services
{
    public class MockDataStore : IDataStore<Student>
    {
        HttpClient client;
        public ObservableCollection<Student> students { get; set; }
        public Student student { get; set; }
        public string url { get; set; }

        public MockDataStore()
        {
            client = new HttpClient();
            students = new ObservableCollection<Student>();
        }


       

        public async Task<ObservableCollection<Student>> GetStudentsAsync()
        {
            url = "http://etestapi.test.eminenttechnology.com/api/Student";
            var uri = new Uri(url);
            try
            {
                var response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    students = JsonConvert.DeserializeObject<ObservableCollection<Student>>(content);
                    return students;
                }
            }

            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
            return null;
        }

        public async Task<Student> GetStudentAsync(Guid id)
        {
            url = $"http://etestapi.test.eminenttechnology.com/api/Student/{id}";
            var uri = new Uri(url);
            try
            {
                var response = await client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(content);
                    return student;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
            return null;
        }

        public Task<bool> UpdateStudentAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteStudentAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async  Task<bool> AddStudentAsync(Student student)
        {
            url = "http://etestapi.test.eminenttechnology.com/api/Student";
            var uri = new Uri(url);
            try
            {
                var json = JsonConvert.SerializeObject(student);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(uri, data);

                
                if(response.IsSuccessStatusCode)
                {
                    return true;
                }
               
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);

            }
            return false;
        }
    }
}