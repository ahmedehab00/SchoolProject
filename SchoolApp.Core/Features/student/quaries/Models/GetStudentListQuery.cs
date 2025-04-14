using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using SchoolApp.Data.Entities;

namespace SchoolApp.Core.Features.student.quaries.Models
{
    public class GetStudentListQuery:IRequest<List<Student>>
    {
    }
}
