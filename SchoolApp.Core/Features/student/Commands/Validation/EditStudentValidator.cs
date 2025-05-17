using FluentValidation;
using SchoolApp.Core.Features.student.Commands.Models;
using SchoolApp.Service.Abstract;

namespace SchoolApp.Core.Features.student.Commands.Validation
{
    public class EditStudentValidator : AbstractValidator<EditStudentCommand>
    {

        #region Fields
        private readonly IStudentService _studentService;

        #endregion

        #region Constructor
        public EditStudentValidator(IStudentService studentService)
        {
            _studentService = studentService;
            ApplyValidationRules();
            ApplyCustomValidationRules();
        }



        #endregion

        #region Actions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name Must Not be Empty ")
                .NotNull().WithMessage("Name Must Not be Null")
                .MaximumLength(100).WithMessage("Max Length is 10");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("{PropertyName} Must Not be Empty ")
                .NotNull().WithMessage("{PropertyName} Must Not be Null")
                .MaximumLength(50).WithMessage("Max Length is 50");
        }


        public void ApplyCustomValidationRules()
        {
            RuleFor(x => x.Name)
                .MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
                .WithMessage("Name Is Exist");

        }
        #endregion


    }
}
