using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI4.Models
{

    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? DepartmentId { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        public string DateBirth { get; set; }
        public string Address { get; set; }
        public virtual Department Department { get; set; }



    }
}
