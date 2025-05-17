using SchoolApp.Data.Entities;
using SchoolApp.Data.Helper;

namespace SchoolApp.Service.Abstract
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsListAsync();
        Task<Student> GetStudentByIdWithIncludeAsync(int id);
        Task<Student> GetByIdAsync(int id);
        Task<string> AddAsync(Student student);
        Task<bool> IsNameExist(string name);
        Task<bool> IsNameExistExcludeSelf(string name, int id);
        Task<string> EditAsync(Student student);
        Task<string> DeleteAsync(Student student);
        IQueryable<Student> GetStudentsQuerable();
        IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search);

    }
}
