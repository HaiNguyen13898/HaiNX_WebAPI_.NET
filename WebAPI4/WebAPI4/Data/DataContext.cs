using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
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
            modelBuilder.Entity<Employee>()
               .HasOne(e => e.Department)
               .WithMany(d => d.Employees)
               .HasForeignKey(d => d.DepartmentId)
               .OnDelete(DeleteBehavior.NoAction);
        }



        //public override void OnModelCreating(ModelBuilder modelBuilder)
        //     {
        //          modelBuilder.Entity<Employee>()
        //             .HasOne(e => e.Department)
        //             .WithMany(d => d.Employees);
        //     }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Department> Depart { get; set; }


    }
}
