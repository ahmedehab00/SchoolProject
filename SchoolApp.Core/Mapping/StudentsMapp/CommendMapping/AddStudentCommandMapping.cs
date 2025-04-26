using AutoMapper;
using SchoolApp.Core.Features.student.Commands.Models;
using SchoolApp.Core.Features.student.quaries.Results;
using SchoolApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolApp.Core.Mapping.StudentsMapp
{
    public partial class StudentProfile
    {
        public void AddStudentCommandMapping()
        {
            CreateMap<AddStudentCommand,Student>()
                .ForMember(dest => dest.DID, opt => opt.MapFrom(src => src.DepartmentId));
        }
    }
}