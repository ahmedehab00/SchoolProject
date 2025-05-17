using MediatR;
using SchoolApp.Core.Bases;

namespace SchoolApp.Core.Features.student.Commands.Models
{
    public class EditStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int DepartmentId { get; set; }
    }
}
