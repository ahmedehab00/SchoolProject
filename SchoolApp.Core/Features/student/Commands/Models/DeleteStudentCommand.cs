using MediatR;
using SchoolApp.Core.Bases;

namespace SchoolApp.Core.Features.student.Commands.Models
{
    public class DeleteStudentCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteStudentCommand(int id)
        {

            Id = id;
        }
    }
}
