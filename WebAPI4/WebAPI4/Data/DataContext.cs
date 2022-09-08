using Microsoft.EntityFrameworkCore;
using WebAPI4.Models;

namespace WebAPI4.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Department> Depart { get; set; }
    }
}
