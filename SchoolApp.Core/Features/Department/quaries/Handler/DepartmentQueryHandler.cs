using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolApp.Core.Bases;
using SchoolApp.Core.Features.Department.quaries.Models;
using SchoolApp.Core.Features.Department.quaries.Results;
using SchoolApp.Core.ShResources;
using SchoolApp.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Core.Features.Department.quaries.Handler
{
    public class DepartmentQueryHandler : ResponseHandler,
        IRequestHandler<GetDepartmentByIdQuary, Response<GetDepartmentByIdResponse>>
    {
        #region Feild

        #endregion
        private  readonly IDepartmentService _departmentService;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;
        #region Constructor
        public DepartmentQueryHandler(IStringLocalizer<SharedResources> stringLocalizer, IDepartmentService departmentService, IMapper mapper) :base(stringLocalizer) 
        {
            _departmentService = departmentService;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
            
        }
        #endregion
        #region Handle Function

        public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuary request, CancellationToken cancellationToken)
        {
            //service get by id include st sub ins

            var response= await _departmentService.GetDepartmentById(request.Id);
            //check is not exist
            if (response == null) return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]);
            //mapping
            var mapper=_mapper.Map<GetDepartmentByIdResponse>(response);
            //return response
            return Success(mapper);
        }

        #endregion
    }
}
