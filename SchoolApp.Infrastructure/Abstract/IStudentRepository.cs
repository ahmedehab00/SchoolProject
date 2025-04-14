using SchoolApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Infrastructure.Abstract
{
    public interface IStudentRepository
    {
        Task<List<Student>> GetAllStudentAsync();
    }
}
