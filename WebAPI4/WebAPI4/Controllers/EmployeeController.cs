using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI4.Data;
using WebAPI4.Dto;
using WebAPI4.Models;


namespace WebAPI4.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EmployeeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetEmployee()
        {
            var employee = await _dataContext.Employees.ToListAsync();

            return employee;
    }

        [HttpPost]
        public async Task<ActionResult<List<Employee>>> CreateEmployee(EmployeeDto employeeDto)
        {
            var department = await _dataContext.Depart.FindAsync(employeeDto.DepartmentId);
            if(department == null)
            {
                return NotFound();
            }

            var employees = new Employee()
            {
                Name = employeeDto.Name,
                DateBirth = employeeDto.DateBirth,
                Address = employeeDto.Address,
                Department = department
            
            };
            await _dataContext.AddAsync(employees);
            await _dataContext.SaveChangesAsync();
            return Ok( employees);
        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, EmployeeDto employeeDto)
        {
            var UpdateEmployee = _dataContext.Employees.Find(id);
            if(UpdateEmployee == null)
            {
                return NotFound();
            }

            UpdateEmployee.Name = employeeDto.Name;
            UpdateEmployee.Address = employeeDto.Address;
            UpdateEmployee.DateBirth = employeeDto.DateBirth;
            UpdateEmployee.DepartmentId = employeeDto.DepartmentId;
            await _dataContext.SaveChangesAsync();
            return Ok(UpdateEmployee);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            var employee = await _dataContext.Employees.Where(e => e.Id == id).ToListAsync();
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteEmployee([FromRoute] int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if(employee != null) { 
                _dataContext.Remove(employee);
                await _dataContext.SaveChangesAsync();
                return Ok(employee);
            }
            return NotFound();
        }




    }
}
