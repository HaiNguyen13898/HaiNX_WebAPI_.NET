using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI4.Data;
using WebAPI4.Models;

namespace WebAPI4.Controllers
{
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
        public async Task<IActionResult> GetEmployee()
        {
            return Ok( await _dataContext.Employees.ToListAsync());
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee(Employee employee)
        {
            var employees = new Employee()
            {
                Name = employee.Name,
                DateBirth = employee.DateBirth,
                Address = employee.Address,
            };
            await _dataContext.AddAsync(employees);
            await _dataContext.SaveChangesAsync();
            return Ok( employees);
        }
        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateEmployee([FromRoute] int id, Employee employee)
        {
            var UpdateEmployee = _dataContext.Employees.Find(id);
            if(UpdateEmployee == null)
            {
                return NotFound();
            }

            UpdateEmployee.Name = employee.Name;
            UpdateEmployee.Address = employee.Address;
            UpdateEmployee.DateBirth = employee.DateBirth;
            await _dataContext.SaveChangesAsync();
            return Ok(UpdateEmployee);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetEmployee([FromRoute] int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);   
            if(employee == null)
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
