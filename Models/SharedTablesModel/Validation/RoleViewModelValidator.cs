using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UIBlazor.Models.SharedTablesModel.Validation
{
    //public class RoleViewModelValidator : AbstractValidator<RoleViewModel>
    //{
    //    public RoleViewModelValidator()
    //    {
    //        RuleFor(x => x.Name)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(3).WithMessage("Минимальная длина 3 символа")
    //            .MaximumLength(50).WithMessage("Максильная длина 50 символов")
    //            .Must(x => IsValidName(x)).WithMessage("Проверьте правильность ввода, пример: RootAdmin");
    //    }

    //    public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
    //    {
    //        var result = await ValidateAsync(ValidationContext<RoleViewModel>
    //            .CreateWithOptions((RoleViewModel)model, x => x.IncludeProperties(propertyName)));
    //        if (result.IsValid)
    //            return Array.Empty<string>();
    //        return new List<string>() { result.Errors[0].ErrorMessage };
    //    };



    //    private bool IsValidName(string name)
    //    {
    //        return !Regex.IsMatch(name, ("^.*[^A-zА-яЁё].*$"));
    //    }
    //}
}
