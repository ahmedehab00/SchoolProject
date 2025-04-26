using MediatR;
using SchoolApp.Core.Bases;
using SchoolApp.Core.Features.student.quaries.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Core.Features.student.quaries.Models
{
    public class GetStudentByIdQuery:IRequest<Response<GetSingleStudentResponse>>
    {
        public int Id { get; set; }
        public GetStudentByIdQuery(int id)
        {
            Id = id;
        }
    }
}
