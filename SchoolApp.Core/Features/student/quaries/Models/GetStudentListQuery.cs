using MediatR;
using SchoolApp.Core.Bases;
using SchoolApp.Core.Features.student.quaries.Results;
using SchoolApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Core.Features.student.quaries.Models
{
    public class GetStudentListQuery:IRequest<Response<List<GetStudentListResponse>>>
    {
    }
}
