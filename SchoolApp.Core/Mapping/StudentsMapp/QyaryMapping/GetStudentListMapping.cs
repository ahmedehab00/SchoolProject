using SchoolApp.Core.Features.student.quaries.Results;
using SchoolApp.Data.Entities;

namespace SchoolApp.Core.Mapping.StudentsMapp
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, GetStudentListResponse>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DNameAr))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
    }
}
