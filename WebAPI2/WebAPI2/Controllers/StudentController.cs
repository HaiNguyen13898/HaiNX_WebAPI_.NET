using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI2.Models;
using WebAPI2.Services;

namespace WebAPI2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _studentService.GetStudentList();
            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var result = await _studentService.GetStudentById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee([FromBody] Student student)
        {
            var result = await _studentService.CreateStudent(student);

            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent([FromBody] Student student)
        {
            var result = await _studentService.UpdateStudent(student);

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var result = await _studentService.DeleteStudent(id);
            return Ok(result);
        }





    }
}
