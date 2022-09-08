using System.Data.Entity;
using WebAPI3.Models;

namespace WebAPI3.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base(nameOrConnectionString: "EmployeeDb")
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
