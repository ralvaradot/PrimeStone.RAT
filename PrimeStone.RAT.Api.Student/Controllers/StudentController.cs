using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrimeStone.RAT.Common.Interface;
using PrimeStone.RAT.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PrimeStone.RAT.Api.Student.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: api/<StudentController>
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> Get()
        {
            return await _studentService.ListStudentss();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public StudentDto Get(int id)
        {
            return _studentService.GetStudent(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public int Post(StudentDto student)
        {
            return _studentService.AddStudent(student, User.Identity.Name);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public int Put(int id, StudentDto student)
        {
            return _studentService.UpdateStudent(student, User.Identity.Name);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _studentService.DeleteStudent(id);
        }
    }
}
