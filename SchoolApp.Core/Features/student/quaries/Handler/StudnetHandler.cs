using AutoMapper;
using Azure;
using MediatR;
using SchoolApp.Core.Bases;
using SchoolApp.Core.Features.student.quaries.Models;
using SchoolApp.Core.Features.student.quaries.Results;
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

    public class StudentHandler : ResponseHandler,IRequestHandler<GetStudentListQuery, Bases.Response<List<GetStudentListResponse>>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public StudentHandler(IStudentService studentService,IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        #region Handle Function
        #endregion
        public async Task<Bases.Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList= await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            return Success( studentListMapper);
        }
    }
}
