using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolApp.Core.Bases;
using SchoolApp.Core.Features.student.Commands.Models;
using SchoolApp.Core.ShResources;
using SchoolApp.Data.Entities;
using SchoolApp.Service.Abstract;

namespace SchoolApp.Core.Features.student.Commands.Handler
{
    public class StudentCommandHandler : ResponseHandler,
                                       IRequestHandler<AddStudentCommand, Response<string>>,
                                       IRequestHandler<EditStudentCommand, Response<string>>,
                                       IRequestHandler<DeleteStudentCommand, Response<string>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructor
        public StudentCommandHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }


        #endregion

        #region Handle Functions
        public async Task<Response<string>> Handle(AddStudentCommand request, CancellationToken cancellationToken)
        {
            //mapping Between Request and student
            var studentMapper = _mapper.Map<Student>(request);
            //add
            var result = await _studentService.AddAsync(studentMapper);
            // return response
            if (result == "Success") return Created("");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(EditStudentCommand request, CancellationToken cancellationToken)
        {
            //check if the Id is Exist or Not
            var student = await _studentService.GetByIdAsync(request.Id);
            //return NotFound
            if (student == null)
            {
                return NotFound<string>("Studnet is Not Found");
            }
            //mapping Between request and student
            var studentMapper = _mapper.Map<Student>(request);
            //call srevice that make Edit 
            var result = await _studentService.EditAsync(studentMapper);
            //return response
            if (result == "Success") return Success($"Updated Seccessfully {studentMapper.StudID}");
            else return BadRequest<string>();
        }

        public async Task<Response<string>> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            //check if the Id is Exist or Not
            var student = await _studentService.GetByIdAsync(request.Id);
            //return NotFound
            if (student == null)
            {
                return NotFound<string>("Studnet is Not Found");
            }
            //call srevice that make Delete
            var result = await _studentService.DeleteAsync(student);
            //return response
            if (result == "Success") return Deleted<string>($"Deleted Seccessfully {request.Id}");
            else return BadRequest<string>();
        }
        #endregion
    }
}
