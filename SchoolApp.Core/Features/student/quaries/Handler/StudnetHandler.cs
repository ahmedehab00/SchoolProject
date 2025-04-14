using MediatR;
using SchoolApp.Core.Features.student.quaries.Models;
using SchoolApp.Data.Entities;
using SchoolApp.Service.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Core.Features.student.quaries.Handler
{
    public class StudnetHandler : IRequestHandler<GetStudentListQuery, List<Student>>
    {
        #region Fields
        private readonly IStudentService _studentService;

        #endregion

        #region Constructor
        public StudnetHandler(IStudentService studentService)
        {
            _studentService = studentService;
        }
        #endregion

        #region Handle Function
        #endregion
        public async Task<List<Student>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            return await _studentService.GetStudentsListAsync();
        }
    }
}
