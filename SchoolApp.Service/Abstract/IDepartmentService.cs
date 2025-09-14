using SchoolApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Service.Abstract
{
    public interface IDepartmentService
    {
        Task<Department>GetDepartmentById(int id);
    }
}
