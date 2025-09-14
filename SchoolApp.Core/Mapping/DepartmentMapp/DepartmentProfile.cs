using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Core.Mapping.DepartmentMapp
{
    public partial class DepartmentProfile : Profile
    {
        public DepartmentProfile() 
        {
            GetDepartmentByIdMapping();
        }
    }
}
