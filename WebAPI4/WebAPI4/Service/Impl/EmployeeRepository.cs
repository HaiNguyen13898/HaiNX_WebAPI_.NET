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

        // record in page
        public static int PAGE_SIZE { get; set; } = 2;

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
            return dataContext.Employees.Include(e => e.Department).ToList();
        }

        public Employee getEmployeeById(int id)
        {
            var employee = dataContext.Employees.Where(e => e.Id == id).FirstOrDefault();
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

        public List<Employee> getAllSearchPaging(string name, string dateBirth, string? nameDepart, int page = 1)
        {
            #region List-Search
            var list = dataContext.Employees.Include(e => e.Department).AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
            {
                list = list.Where(e =>
                e.Name.ToLower().Contains(name) || e.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(dateBirth))
            {
                list = list.Where(e => e.DateBirth.Contains(dateBirth));
            }
            if (!string.IsNullOrWhiteSpace(nameDepart))
            {
                list = list.Where(e => e.Department.Name.ToLower().Contains(nameDepart)
                || e.Department.Name.Contains(nameDepart));
            }
            #endregion

            #region Paging
            //list = list.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE);
            #endregion

            //var result = list.Select(e => new Employee
            //{
            //    Id = e.Id,
            //    Name = e.Name,
            //    Address = e.Address,
            //    DateBirth = e.DateBirth,
            //    DepartmentId = e.Department.Id,
            //    Department = e.Department,          
            //}); 
            var result = PageList<Employee>.Create(list, page, PAGE_SIZE);
            return result.ToList();
        }
    }
}