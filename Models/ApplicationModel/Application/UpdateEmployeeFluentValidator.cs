using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class UpdateEmployeeFluentValidator : AbstractValidator<UpdateEmployeeOrApplicationViewModel>
    {
        public UpdateEmployeeFluentValidator()
        {
            RuleFor(x => x.Employee)
                .NotNull().WithMessage("Укажите сотрудника");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<UpdateEmployeeOrApplicationViewModel>
                .CreateWithOptions((UpdateEmployeeOrApplicationViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };
    }
}
