using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolApp.Core.Bases;
using SchoolApp.Core.Features.student.quaries.Models;
using SchoolApp.Core.Features.student.quaries.Results;
using SchoolApp.Core.ShResources;
using SchoolApp.Core.Wrappers;
using SchoolApp.Data.Entities;
using SchoolApp.Service.Abstract;
using System.Linq.Expressions;

namespace SchoolApp.Core.Features.student.quaries.Handler
{

    public class StudentQueryHandler : ResponseHandler,
        IRequestHandler<GetStudentListQuery, Bases.Response<List<GetStudentListResponse>>>,
        IRequestHandler<GetStudentByIdQuery, Bases.Response<GetSingleStudentResponse>>,
        IRequestHandler<GetStudentPaginatedListQuery, PaginatedResult<GetStudentPaginatedListResponse>>
    {
        #region Fields
        private readonly IStudentService _studentService;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;




        #endregion

        #region Constructor
        public StudentQueryHandler(IStudentService studentService, IMapper mapper,
           IStringLocalizer<SharedResources> stringLocalizer) : base(stringLocalizer)
        {
            _studentService = studentService;
            _mapper = mapper;
            _stringLocalizer = stringLocalizer;
        }
        #endregion

        #region Handle Functions

        public async Task<Bases.Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentsListAsync();
            var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
            var result = Success(studentListMapper);
            result.Meta = new { Count = studentListMapper.Count() };
            return result;
        }

        public async Task<Bases.Response<GetSingleStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            var studnet = await _studentService.GetStudentByIdWithIncludeAsync(request.Id);
            if (studnet == null) return NotFound<GetSingleStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            var result = _mapper.Map<GetSingleStudentResponse>(studnet);
            return Success(result);
        }


        public async Task<PaginatedResult<GetStudentPaginatedListResponse>> Handle(GetStudentPaginatedListQuery request, CancellationToken cancellationToken)
        {
            Expression<Func<Student, GetStudentPaginatedListResponse>> expression = e => new GetStudentPaginatedListResponse(e.StudID, e.Localize(e.NameAr, e.NameEn), e.Address, e.Department.DNameAr);
            //var querable = _studentService.GetStudentsQuerable();
            var FilterQuery = _studentService.FilterStudentPaginatedQuerable(request.OrderBy, request.Search);
            var PaginatedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedList.Meta = new { Count = PaginatedList.Data.Count() };
            return PaginatedList;
        }
        #endregion
    }
}
