using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
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
        #endregion
    }
}
