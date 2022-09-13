using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Web1.Data;
using Web1.Models;

namespace Web1.Controllers
{
    [Route("api/employee")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private readonly DataContext dataContext;

        public EmployeeController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public async Task<IActionResult> Index()
        {
            //var data = await  dataContext.employees.Include
            //    (i => i.Department).Select(x => new { x.Id,x.Name,x.Age,x.Email,x.Address }).ToListAsync();
            return Ok(await dataContext.employees.ToListAsync());
        
        }
    }
}
