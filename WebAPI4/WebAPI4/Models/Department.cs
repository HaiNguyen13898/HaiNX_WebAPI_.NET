using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAPI4.Models
{
    public class Department
    {
        //public department()
        //{
        //      employees = new hashset<Employee>();
        //}

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } 

        [JsonIgnore]
        public List<Employee> Employees { get; set; }
       
    }
}
