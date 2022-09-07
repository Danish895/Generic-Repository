using Generic_Repository_For_Models.Model;
using Generic_Repository_For_Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Generic_Repository_For_Models.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService<Student> _UserServiceStudent;
        private IUserService<Employee> _UserServiceEmployee;

        public UserController(IUserService<Student> userServiceStudent, IUserService<Employee> userServiceEmployee)
        {
            _UserServiceStudent = userServiceStudent;
            _UserServiceEmployee = userServiceEmployee;
        }

        [Route("Student")]
        [HttpGet]
        public async Task<IEnumerable<Student>> getStudentInfo()
        {
            return await _UserServiceStudent.GetAllUser();
        }

        [Route("Emplyee")]
        [HttpGet]
        public async Task<IEnumerable<Employee>> getEmployeeInfo()
        {
            return await _UserServiceEmployee.GetAllUser();
        }

        [Route("StudentByName/{Name}")]
        [HttpGet]
        public async Task<Student> findByName(string Name)
        {
            return await _UserServiceStudent.findByName(a => a.Name == Name);
        }
    }
}
