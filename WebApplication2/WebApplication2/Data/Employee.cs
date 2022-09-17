using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Data
{
    public class Employee
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string birthDate  { get; set; }
    }
}
