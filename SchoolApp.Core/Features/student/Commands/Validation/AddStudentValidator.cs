using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolApp.Core.Features.student.Commands.Models;
using SchoolApp.Core.ShResources;
using SchoolApp.Service.Abstract;

namespace SchoolApp.Core.Features.student.Commands.Validation
{
    public class AddStudentValidator : AbstractValidator<AddStudentCommand>
    {
        #region Fields
        private readonly IStudentService _studentService;
        IStringLocalizer<SharedResources> _stringLocalizer;

        #endregion

        #region Constructor
        public AddStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources> stringLocalizer)
        {
            _studentService = studentService;
            _stringLocalizer = stringLocalizer;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }



        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage("Name Must Not be Null")
                .MaximumLength(10).WithMessage("Max Length is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} Must Not be Empty ")
                .NotNull().WithMessage("{PropertyName} Must Not be Null")
                .MaximumLength(50).WithMessage("Max Length is 50");
        }


        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
                .WithMessage("Name Is Exist");

        }
        #endregion


    }
}
