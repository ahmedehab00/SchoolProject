using Microsoft.AspNetCore.Mvc;
using SchoolApp.Core.Features.Department.quaries.Models;
using SchoolApp.Data.AppMetaData;
using SchoolAppApi.Bases;

namespace SchoolAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : AppControllerBase
    {
        [HttpGet(Router.DepartmentRouting.GetById)]
        public async Task<IActionResult> GetDepartmentById([FromRoute] int id)
        {
            var response = await Mediator.Send(new GetDepartmentByIdQuary(id));
            return NewResult(response);
        }


    }
}
