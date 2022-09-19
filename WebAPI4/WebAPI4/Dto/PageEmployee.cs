using WebAPI4.Models;

namespace WebAPI4.Dto
{
    public class PageEmployee
    {
        public List<Employee> Employees { get; set; }
        public int Pages { get; set; }
        public int CurrenPage { get; set; }
    }
}
