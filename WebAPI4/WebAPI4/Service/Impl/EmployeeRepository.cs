using Microsoft.AspNetCore.Mvc;
using WebAPI4.Data;
using WebAPI4.Dto;
using WebAPI4.Models;

namespace WebAPI4.Service.Impl
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly DataContext dataContext;
        public EmployeeRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public Employee addEmployee(EmployeeDto employeeDto)
        {
            var _employee = new Employee
            {
                Name = employeeDto.Name,
                DateBirth = employeeDto.DateBirth,
                Address = employeeDto.Address,
                DepartmentId = employeeDto.DepartmentId
            };
            dataContext.Add(_employee);
            dataContext.SaveChanges();
            return _employee;
        }

        public void deleteById(int id)
        {
            var employee = dataContext.Employees.Find(id);
            if (employee != null)
            {
                dataContext.Remove(employee);
                dataContext.SaveChanges();
            }
        }

        public ActionResult<IEnumerable<Employee>> getListEmployee()
        {
            return dataContext.Employees.Include(e=> e.Department).ToList();
        }

        public Employee getEmployeeById(int id)
        {
            var employee = dataContext.Employees.Find(id);
            if (employee != null)
            {
                return employee;
            }
            return null;
        }

        public void update(EmployeeDto employeeDto)
        {
            var employeeUpdate = dataContext.Employees.Find(employeeDto.Id);
            if (employeeUpdate != null)
            {
                employeeUpdate.Name = employeeDto.Name;
                employeeUpdate.Address = employeeDto.Address;
                employeeUpdate.DateBirth = employeeDto.DateBirth;
                employeeUpdate.DepartmentId = employeeDto.DepartmentId;
                dataContext.SaveChanges();
            }
        }
    }
}
