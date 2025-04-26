using SchoolApp.Data.Entities;
using SchoolApp.Infrastructure.InfrastructureBases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Infrastructure.Abstract
{
    public interface IStudentRepository:IGenericRepositoryAsync<Student>
    {
        Task<List<Student>> GetAllStudentAsync();
    }
}
