using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class SelectPriorityFluentValidator : AbstractValidator<SelectPriorityViewModel>
    {
        public SelectPriorityFluentValidator()
        {
            RuleFor(x => x.Priority)
                .NotNull().WithMessage("Выберите состояние заявки");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<SelectPriorityViewModel>
                .CreateWithOptions((SelectPriorityViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };
    }
}
