using Microsoft.EntityFrameworkCore.Metadata;
using System.Text.Json.Serialization;
using WebAPI4.Models;

namespace WebAPI4.Dto
{
    public class EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public  int DepartmentId { get; set; }        
    }
}
