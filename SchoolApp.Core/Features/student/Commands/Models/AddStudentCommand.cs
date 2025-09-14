using MediatR;
using SchoolApp.Core.Bases;
using System.ComponentModel.DataAnnotations;

namespace SchoolApp.Core.Features.student.Commands.Models
{
    public class AddStudentCommand : IRequest<Response<string>>
    {
        [Required]
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        [Required]
        public string Address { get; set; }
        public string Phone { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
