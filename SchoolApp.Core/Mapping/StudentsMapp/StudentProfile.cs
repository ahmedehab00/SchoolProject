using AutoMapper;
using SchoolApp.Core.Features.student.quaries.Results;
using SchoolApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Core.Mapping.StudentsMapp
{
    public partial class StudentProfile:Profile
    {
        public StudentProfile()
        {
            GetStudentListMapping();
            GetStudentByIdMapping();
            AddStudentCommandMapping();
        }
    }
}
