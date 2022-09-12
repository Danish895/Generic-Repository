using GenericRepository.Model;
using GenericRepository.Services;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace GenericRepository.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase 
    {
        private IGenericService<Student> _studentService { get; set; }
        private IGenericService<Employee> _employeeService { get; set; }
       // public IServiceProvider Provider { get; set; }

        //public UserController(IGenericService<Student> StudentService, IGenericService<Employee> EmployeeService) 
        //{
            
        //    //_studentService = Provider.GetRequiredService<IGenericService<Student>>();
        //    //_employeeService = Provider.GetRequiredService<IGenericService<Employee>>();
        //    //_employeeService = (IGenericService<Employee>)service;
        //    _employeeService = EmployeeService;
        //    _studentService = StudentService;
        //}

        public UserController(IServiceProvider Provider)
        {
            _studentService = Provider.GetRequiredService<IGenericService<Student>>();
            _employeeService = Provider.GetRequiredService<IGenericService<Employee>>();
        }


        [Route("GetAllStudents")]
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudentAsync()
        {
            return await _studentService.GetAsyncAll();
        }


        [Route("AddStudent")]
        [HttpPost]
        public async Task<bool> AddAStudentAsync(Student student)
        {
            try
            {
                return await _studentService.AddAsyncStudent(student);
            }
            catch
            {
                return false;
            }
        }

        [Route("GetAllEmployees")]
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployeeAsync()
        {
            return await _employeeService.GetAsyncAll();
        }


        [Route("GetInfoByName/{Name}")]
        [HttpGet]
        public async Task<Student> FirstOrDefaultAsync(string Name)
        {
            return await _studentService.FirstOrDefaultAsync(a => a.Name == Name);
        }


        [Route("GetAllStudentsWithHTTPCall")]
        [HttpGet]
        public async Task<IEnumerable<Student>> GetStudentWithHttpCallAsync()
        {
            var url = "https://localhost:7028/api/User/GetAllStudents";
            using var client = new HttpClient();
            var msg = new HttpRequestMessage(HttpMethod.Get, url);

            var res = await client.SendAsync(msg);

            var content = await res.Content.ReadAsStringAsync();

            List<Student> StudentDetails = JsonConvert.DeserializeObject<List<Student>>(content);
            return StudentDetails;
        }

        [Route("FirstOrDefaultWithHTTPcallAsync/{Name}")]
        [HttpGet]
        public async Task<Student> FirstOrDefaultWithHTTPcallAsync(string Name)
        {
            var url = $"https://localhost:7028/api/User/GetInfoByName/{Name}";
            var client = new HttpClient();
            var msg = new HttpRequestMessage(HttpMethod.Get, url);

            var response = await client.SendAsync(msg);

            var responseContent = await response.Content.ReadAsStringAsync();

            Student StudentDetail = JsonConvert.DeserializeObject<Student>(responseContent);
            return StudentDetail;
        }

        [Route("AddStudentWithHttpCallAsync")]
        [HttpPost]

        public async Task<bool> AddStudentWithHttpCallAsync(Student student)
        {
            var url = "https://localhost:7028/api/User/AddStudent";
            var client = new HttpClient();
            //var msg = new HttpRequestMessage(HttpMethod.Post, url);

            var json = JsonConvert.SerializeObject(student);

            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync(url, data);
            var responseContent = await response.Content.ReadAsStringAsync();
            return true;
        }
    }
}
