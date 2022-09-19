using Microsoft.AspNetCore.Mvc;
using WebAPI4.Dto;
using WebAPI4.Models;

namespace WebAPI4.Service
{
    public interface IEmployeeRepository
    {
        ActionResult<IEnumerable<Employee>> getListEmployee();
        List<Employee> getAllSearchPaging(string name, string dateBirth, int? idDepart);
        Employee getEmployeeById(int id);
        Employee addEmployee(EmployeeDto employeeDto);
        void update(EmployeeDto employeeDto);
        void deleteById(int id);
    }
}
