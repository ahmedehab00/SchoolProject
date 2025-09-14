using Microsoft.EntityFrameworkCore;
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
    public class DepartmentService:IDepartmentService
    {
        #region Feild
        protected readonly IDepartmentRepository _departmentRepository;
        #endregion

        #region Constructor
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
           
            _departmentRepository = departmentRepository;
        }

        #endregion

        #region Handle Func
        public async Task<Department> GetDepartmentById(int id)
        {
           var student= await _departmentRepository.GetTableNoTracking().Where(x=>x.DID.Equals(id))
                                                            .Include(x=>x.DepartmentSubjects).ThenInclude(x=>x.Subjects)
                                                            .Include(x=>x.Students)
                                                            .Include(x=>x.Instructors)
                                                            .Include(x=>x.Instructor).FirstOrDefaultAsync();
            return student;
        }
        #endregion
    }
}
