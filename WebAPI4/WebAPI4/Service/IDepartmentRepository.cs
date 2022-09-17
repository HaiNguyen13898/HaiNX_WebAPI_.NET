using WebAPI4.Dto;

namespace WebAPI4.Service
{
    public interface IDepartmentRepository
    {
        List<DepartmentDto> getAll();
        DepartmentDto getDepartById(int id);
        void add(DepartmentDto department);
        void update(DepartmentDto department);
        void deleteById(int id);
    }
}
