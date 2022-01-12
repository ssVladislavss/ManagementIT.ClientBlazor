using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Department;

namespace UIBlazor.Models.SharedTablesModel.Validation
{
    public class DepartamentFluentValidator : AbstractValidator<CreateOrEditDepartmentViewModel>
    {
        public DepartamentFluentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(2).WithMessage("Минимальная длина 2 символа")
                .MaximumLength(50).WithMessage("Максильная длина 50 символов");
            RuleFor(x => x.Subdivision)
                .NotNull().WithMessage("Укажите подразделение");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<CreateOrEditDepartmentViewModel>
                .CreateWithOptions((CreateOrEditDepartmentViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };
    }
}
