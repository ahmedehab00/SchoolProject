using MediatR;
using SchoolApp.Core.Features.student.quaries.Results;
using SchoolApp.Core.Wrappers;
using SchoolApp.Data.Helper;

namespace SchoolApp.Core.Features.student.quaries.Models
{
    public class GetStudentPaginatedListQuery : IRequest<PaginatedResult<GetStudentPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public StudentOrderingEnum OrderBy { get; set; }
        public string? Search { get; set; }
    }
}
