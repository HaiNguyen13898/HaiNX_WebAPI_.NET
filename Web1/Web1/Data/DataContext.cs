using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Reflection.Emit;
using Web1.Models;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace Web1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();

        }

        public System.Data.Entity.DbSet<Employee> employees { get; set; }
        public System.Data.Entity.DbSet<Department> department { get; set; }



        //protected override void onmodelcreating(Modelbuilder modelbuilder)
        //{
        //    //base.onmodelcreating(modelbuilder);
        //    modelbuilder.useserialcolumns();

        //    //modelbuilder.entity<department>().hasmany(x => x.employees);

        //    modelbuilder.entity<employee>()
        //                .hasone(e => e.department)
        //                .withmany(d => d.employees);

        //}




        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>()
        //   .HasRequired<Department>(e => e.Department)
        //   .WithMany(d => d.Employees)
        //   .HasForeignKey<int>(e => e.DepartmentId);
        //}

    }
}
