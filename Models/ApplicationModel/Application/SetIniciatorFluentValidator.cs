using FluentValidation;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class SetIniciatorFluentValidator : AbstractValidator<SetIniciatorViewModel>
    {
        public SetIniciatorFluentValidator()
        {
            RuleFor(x => x.Employee)
                .NotNull().WithMessage("Укажите сотрудника");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<SetIniciatorViewModel>
                .CreateWithOptions((SetIniciatorViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };
    }
}
