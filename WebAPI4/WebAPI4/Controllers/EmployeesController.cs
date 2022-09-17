using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WebAPI4.Dto;
using WebAPI4.Models;
using WebAPI4.Service;

namespace WebAPI4.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        private IEmployeeRepository employeeRepository;

        public EmployeesController(IEmployeeRepository iEmployeeRepository)
        {
            employeeRepository = iEmployeeRepository;
        }
        // GET: List
        [HttpGet]
        public IActionResult getListEmployee()
        {
            try
            {
                return Ok(employeeRepository.getListEmployee());
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }

        // GET: Employee by id
        [HttpGet("{id}")]
        public IActionResult getEmployeeById(int id)
        {
            try
            {
                var employee = employeeRepository.getEmployeeById(id);
                if(employee == null)
                {
                    return NotFound();
                }
                return Ok(employee);
            }
            catch
            {
                return StatusCode(StatusCodes.Status404NotFound);
            }
        }


        // POST: Add new employee
        [HttpPost]
        public IActionResult createEmployee([FromBody]EmployeeDto employeeDto)
        {
            try
            {
                return Ok(employeeRepository.addEmployee(employeeDto));
                
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult updateEmployee(int id, EmployeeDto employeeDto)
        {
            Employee findEmployeeById = employeeRepository.getEmployeeById(id);
            if (findEmployeeById == null)
            {
                return NotFound();
            }
            employeeRepository.update(employeeDto);
            return Ok("Updated");
        }


        [HttpDelete("{id}")]
        public IActionResult deleteEmployee(int id)
        {
            Employee findEmployeeById = employeeRepository.getEmployeeById(id);

            if (findEmployeeById == null)
            {
                return NotFound("Getting null for student id");
            }
            employeeRepository.deleteById(id);
            return Ok("Value Deleted");
        }




    }
}
