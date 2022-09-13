using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web1.Data;

namespace Web1.Controllers
{
    [Route("api/deparment")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly DataContext dataContext;
        public DepartmentController(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetDepartment()
        {
            return Ok(await dataContext.department.ToListAsync());
        }
    }
}
