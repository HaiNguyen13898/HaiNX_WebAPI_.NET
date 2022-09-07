using WebAPI2.Models;

namespace WebAPI2.Services
{
    public class StudentService : IStudentService
    {
        private readonly IDbService _dbService;

        public StudentService(IDbService dbService)
        {
            _dbService = dbService;
        }   

        public async Task<bool> CreateStudent(Student student)
        {
            var result = await _dbService.EditData(
                "INSERT INTO student (id,name, age, address) VALUES (@Id, @Name, @Age, @Address)",
                student);
            return true;
        }

        public async Task<bool> DeleteStudent(int id)
        {
            var deleteStudent = await _dbService.EditData("DELETE FROM student WHERE id=@Id", new { id });
            return true;
        }

        public async Task<List<Student>> GetStudentList()
        {
            var studentList = await _dbService.GetAll<Student>("SELECT * FROM student", new { });
            return studentList;

        }

        public async Task<Student> UpdateStudent(Student student)
        {
            var updateStudent = await _dbService.EditData(
                "Update student SET name=@Name, age=@Age, address=@Address WHERE id=@Id", 
                student);
            return student;
        }

        public async Task<Student> GetStudent(int id)
        {
            var studentList = await _dbService.GetAsync<Student>("SELECT * FROM student where id=@id", new { id });
            return studentList;
        }
    }
}
