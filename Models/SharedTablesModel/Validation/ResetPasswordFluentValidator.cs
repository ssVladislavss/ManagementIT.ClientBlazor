using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UIBlazor.Models.SharedTablesModel.Validation
{
    //public class ResetPasswordFluentValidator : AbstractValidator<ResetPasswordEmployeeViewModel>
    //{
    //    public ResetPasswordFluentValidator()
    //    {
    //        RuleFor(x => x.UserName)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(5).WithMessage("Минимальная длина логина 5 символов")
    //            .MaximumLength(20).WithMessage("Максильная длина логина 20 символов")
    //            .Must(x => IsValidUserName(x)).WithMessage("Логин не валиден, пример: Example@examle");
    //        RuleFor(x => x.OldPassword)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(8).WithMessage("Минимальная длина 8 символов")
    //            .MaximumLength(16).WithMessage("Максильная длина 16 символов")
    //            .Must(x => IsValidDigit(x)).WithMessage("Пароль должен содержать хотя бы одну цифру")
    //            .Must(x => IsValidLower(x)).WithMessage("Пароль должен содержать хотя бы одну букву в нжнем регистре")
    //            .Must(x => IsValidUpper(x)).WithMessage("Пароль должен содержать хотя бы одну букву в верхнем регистре");
    //        RuleFor(x => x.NewPassword)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(8).WithMessage("Минимальная длина 8 символов")
    //            .MaximumLength(16).WithMessage("Максильная длина 16 символов")
    //            .Must(x => IsValidDigit(x)).WithMessage("Пароль должен содержать хотя бы одну цифру")
    //            .Must(x => IsValidLower(x)).WithMessage("Пароль должен содержать хотя бы одну букву в нжнем регистре")
    //            .Must(x => IsValidUpper(x)).WithMessage("Пароль должен содержать хотя бы одну букву в верхнем регистре");
    //    }

    //    public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
    //    {
    //        var result = await ValidateAsync(ValidationContext<ResetPasswordEmployeeViewModel>
    //            .CreateWithOptions((ResetPasswordEmployeeViewModel)model, x => x.IncludeProperties(propertyName)));
    //        if (result.IsValid)
    //            return Array.Empty<string>();
    //        return new List<string>() { result.Errors[0].ErrorMessage };
    //    };

    //    private bool IsValidUserName(string userName)
    //    {
    //        if (string.IsNullOrEmpty(userName))
    //            return false;
    //        return !Regex.IsMatch(userName, (@"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$"));
    //    }

    //    private bool IsValidDigit(string password)
    //    {
    //        if (string.IsNullOrEmpty(password))
    //            return false;

    //        foreach (var item in password)
    //        {
    //            if (char.IsDigit(item))
    //                return true;
    //        }
    //        return false;
    //    }

    //    private bool IsValidLower(string password)
    //    {
    //        if (string.IsNullOrEmpty(password))
    //            return false;

    //        foreach (var item in password)
    //        {
    //            if (char.IsLower(item))
    //                return true;
    //        }
    //        return false;
    //    }

    //    private bool IsValidUpper(string password)
    //    {
    //        if (string.IsNullOrEmpty(password))
    //            return false;

    //        foreach (var item in password)
    //        {
    //            if (char.IsUpper(item))
    //                return true;
    //        }
    //        return false;
    //    }
    //}
}
