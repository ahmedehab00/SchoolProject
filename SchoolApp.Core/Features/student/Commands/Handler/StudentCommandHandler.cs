using AutoMapper;
using MediatR;
using SchoolApp.Core.Bases;
using SchoolApp.Core.Features.student.Commands.Models;
using SchoolApp.Data.Entities;
using SchoolApp.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Core.Features.student.Commands.Handler
{
    public class StudentCommandHandler:ResponseHandler,
                                       IRequestHandler<AddStudentCommand,Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;

        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService, IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }


        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //mapping Between Request and student
            var studentMapper = _mapper.Map<Student>(request);
            //add
            var result = await _studentService.AddAsync(studentMapper);
            //check condition
            if (result == "Exist") return UnprocessableEntity<string>("Name is Exist");
            // return response
            else if (result == "Success") return Created("Added Seccessfully");

            else return BadRequest<string>();
        }
            #endregion
        }
    }
