using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student= _studentRepository.GetTableNoTracking()
                .Include(x=>x.Department).Where(X =>X.StudID.Equals(id)).FirstOrDefault();

            return student;
        }

        public async Task<string> AddAsync(Student student)
        {
            //Check if Name is Exist or Not
            var studentresult=_studentRepository.GetTableNoTracking().Where(x=>x.Name.Equals(student.Name)).FirstOrDefault();
            if (studentresult != null) return "Exist";

            //Added Student
            //if (student.StudID != null)
            //    student.StudID == null
            await _studentRepository.AddAsync(student);
            return "Success";
                       
        }
        #endregion
    }
}
