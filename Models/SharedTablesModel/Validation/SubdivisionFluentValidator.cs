using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Subdivision;

namespace UIBlazor.Models.SharedTablesModel.Validation
{
    public class SubdivisionFluentValidator : AbstractValidator<SubdivisionViewModel>
    {
        public SubdivisionFluentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(3).WithMessage("Минимальная длина 3 символа")
                .MaximumLength(50).WithMessage("Максильная длина 50 символов");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<SubdivisionViewModel>
                .CreateWithOptions((SubdivisionViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };
    }
}
