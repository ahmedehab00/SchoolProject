using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;
using SchoolApp.Data.Helper;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Service.Abstract;

namespace SchoolApp.Service.Implemantation
{
    public class StudentService : IStudentService
    {
        #region Field
        private readonly IStudentRepository _studentRepository;
        #endregion
        #region Constructor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #endregion
        #region Handle Functions
        public async Task<List<Student>> GetStudentsListAsync()
        {
            return await _studentRepository.GetAllStudentAsync();
        }
        public async Task<Student> GetStudentByIdWithIncludeAsync(int id)
        {
            var student = _studentRepository.GetTableNoTracking()
                .Include(x => x.Department).Where(X => X.StudID.Equals(id)).FirstOrDefault();

            return student;
        }

        public async Task<string> AddAsync(Student student)
        {


            //Added Student

            await _studentRepository.AddAsync(student);
            return "Success";

        }

        public async Task<bool> IsNameExist(string name)
        {
            ////Check if Name is Exist or Not

            var student = _studentRepository.GetTableNoTracking().Where(x => x.NameAr.Equals(name)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<bool> IsNameExistExcludeSelf(string name, int id)
        {
            ////Check if Name is Exist or Not

            var student = _studentRepository.GetTableNoTracking().Where(x => x.NameEn.Equals(name) & !x.StudID.Equals(id)).FirstOrDefault();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditAsync(Student student)
        {
            await _studentRepository.UpdateAsync(student);
            return "Success";
        }

        public async Task<string> DeleteAsync(Student student)
        {
            var trans = _studentRepository.BeginTransaction();
            try
            {
                await _studentRepository.DeleteAsync(student);
                await trans.CommitAsync();
                return "Success";
            }
            catch
            {
                await trans.RollbackAsync();
                return "Failed";
            }

        }

        public async Task<Student> GetByIdAsync(int id)
        {
            var student = await _studentRepository.GetByIdAsync(id);
            return student;

        }

        public IQueryable<Student> GetStudentsQuerable()
        {
            return _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
        }

        public IQueryable<Student> FilterStudentPaginatedQuerable(StudentOrderingEnum orderingEnum, string search)
        {
            var query = _studentRepository.GetTableNoTracking().Include(x => x.Department).AsQueryable();
            if (search != null)
            {
                query = query.Where(x => x.NameAr.Contains(search) || x.Address.Contains(search));

            }
            switch (orderingEnum)
            {
                case StudentOrderingEnum.StudID:
                    query = query.OrderBy(x => x.StudID);
                    break;
                case StudentOrderingEnum.Name:
                    query = query.OrderBy(x => x.NameAr);
                    break;
                case StudentOrderingEnum.Address:
                    query = query.OrderBy(x => x.Address);
                    break;
                case StudentOrderingEnum.DepartmentName:
                    query = query.OrderBy(x => x.Department.DNameAr);
                    break;

            }
            return query;
        }
        #endregion

    }
}
