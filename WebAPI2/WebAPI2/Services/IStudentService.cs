using WebAPI2.Models;

namespace WebAPI2.Services
{
    public interface IStudentService
    {
        Task<bool> CreateStudent(Student student);
        Task<List<Student>> GetStudentList();
        Task<Student> UpdateStudent(Student student);
        Task<bool> DeleteStudent(int key);
        Task<Student> GetStudentById(int id);
    }
}
