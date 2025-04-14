using Microsoft.EntityFrameworkCore;
using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.Abstract;
using SchoolApp.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        #region Fields
        private readonly ApplicationDbContext _context;
        #endregion

        #region Constructor
        public StudentRepository(ApplicationDbContext context) 
        {
            _context = context;
        }
        #endregion
        #region Handles Functions
        public async Task<List<Student>> GetAllStudentAsync()
        {
            return await _context.students.ToListAsync();
        }
        #endregion
    }
}
