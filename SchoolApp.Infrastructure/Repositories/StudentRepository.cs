using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Infrastructure.Context;
using SchoolApp.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Infrastructure.Repositories
{
    public class StudentRepository :GenericRepositoryAsync<Student>, IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _students;
        #endregion

        #region Constructor
        public StudentRepository(ApplicationDbContext dbcontext) :base(dbcontext)
        {
            _students =dbcontext.Set<Student>();
        }
        #endregion
        #region Handles Functions
        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _students.Include(x=>x.Department).ToListAsync();
        }

        
        #endregion
    }
}
