using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class ApplicationTOITViewModelFluentValidator : AbstractValidator<CreateOrEditApplicationToITViewModel>
    {
        public ApplicationTOITViewModelFluentValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty().WithMessage("Опишите заявку");
            RuleFor(x => x.Type)
                .NotNull().WithMessage("Укажите тип заявки");
            RuleFor(x => x.Department)
                .NotNull().WithMessage("Укажите отделение");
            RuleFor(x => x.Room)
                .NotNull().WithMessage("Укажите помещение");
            RuleFor(x => x.Employee)
                .NotNull().WithMessage("Укажите сотрудника");
            RuleFor(x => x.Contact)
                .NotEmpty().WithMessage("Это поле не может быть пустым, укажите контакт в данных сотрудника.");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<CreateOrEditApplicationToITViewModel>
                .CreateWithOptions((CreateOrEditApplicationToITViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };
    }
}
