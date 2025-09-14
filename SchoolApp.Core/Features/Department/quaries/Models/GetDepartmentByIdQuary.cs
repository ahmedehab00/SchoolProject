
using MediatR;
using SchoolApp.Core.Bases;
using SchoolApp.Core.Features.Department.quaries.Results;

namespace SchoolApp.Core.Features.Department.quaries.Models
{
    public class GetDepartmentByIdQuary : IRequest<Response<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public GetDepartmentByIdQuary(int id)
        {
            Id = id;
        }
    }
}
