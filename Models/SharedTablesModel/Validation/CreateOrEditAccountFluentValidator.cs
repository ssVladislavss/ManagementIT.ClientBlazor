using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;

namespace UIBlazor.Models.SharedTablesModel.Validation
{
    //public class CreateOrEditAccountFluentValidator : AbstractValidator<CreateOrEditAccountEmployeeViewModel>
    //{
    //    public CreateOrEditAccountFluentValidator()
    //    {
    //        RuleFor(x => x.SurName)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(3).WithMessage("Минимальная длина имени 3 символа")
    //            .MaximumLength(50).WithMessage("Максильная длина имени 50 символов")
    //            .Must(x => IsValidName(x)).WithMessage("Проверьте правильность ввода, пример: Королёв");
    //        RuleFor(x => x.Name)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(3).WithMessage("Минимальная длина имени 3 символа")
    //            .MaximumLength(50).WithMessage("Максильная длина имени 50 символов")
    //            .Must(x => IsValidName(x)).WithMessage("Проверьте правильность ввода, пример: Владислав");
    //        RuleFor(x => x.Departament)
    //            .NotNull().WithMessage("Укажите отделение");
    //        RuleFor(x => x.Patronumic)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(3).WithMessage("Минимальная длина имени 3 символа")
    //            .MaximumLength(50).WithMessage("Максильная длина имени 50 символов")
    //            .Must(x => IsValidName(x)).WithMessage("Проверьте правильность ввода, пример: Владислав");
    //        RuleFor(x => x.Position)
    //            .NotNull().WithMessage("Укажите должность");
    //        RuleFor(x => x.Email)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .EmailAddress().WithMessage("Email не валиден, пример: example@mail.ru");
    //        RuleFor(x => x.MobileTelephone)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(10).WithMessage("Минимальная длина имени 10 символов")
    //            .MaximumLength(20).WithMessage("Максильная длина имени 15 символов")
    //            .Must(x => IsValidTelephone(x)).WithMessage("Номер не валиден, пример: 8-999-111-22-33");
    //        RuleFor(x => x.WorkTelephone)
    //            .MaximumLength(20).WithMessage("Максильная длина имени 15 символов")
    //            .Must(x => IsValidTelephone(x)).WithMessage("Номер не валиден, пример: 8-99999-7-66-55");
    //        RuleFor(x => x.UserName)
    //            .NotEmpty().WithMessage("Поле не может быть пустым")
    //            .MinimumLength(5).WithMessage("Минимальная длина логина 5 символов")
    //            .MaximumLength(20).WithMessage("Максильная длина логина 20 символов")
    //            .Must(x => IsValidUserName(x)).WithMessage("Логин не валиден, пример: Example_examle");
    //    }

    //    public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
    //    {
    //        var result = await ValidateAsync(ValidationContext<CreateOrEditAccountEmployeeViewModel>
    //            .CreateWithOptions((CreateOrEditAccountEmployeeViewModel)model, x => x.IncludeProperties(propertyName)));
    //        if (result.IsValid)
    //            return Array.Empty<string>();
    //        return new List<string>() {result.Errors[0].ErrorMessage};
    //    };



    //    private bool IsValidName(string name)
    //    {
    //        return !Regex.IsMatch(name, ("^.*[^A-zА-яЁё].*$"));
    //    }

    //    private bool IsValidTelephone(string telephone)
    //    {
    //        if (string.IsNullOrEmpty(telephone))
    //            return true;
    //        var charDigit = Regex.IsMatch(telephone, ("^.*[^A-zА-яЁё].*$"));
    //        var result = Regex.IsMatch(telephone, (@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"));
    //        if (!charDigit)
    //            return charDigit;
    //        return result;
    //    }

        
    //    private bool IsValidUserName(string userName)
    //    {
    //        var result = Regex.IsMatch(userName, (@"^(?=[a-zA-Z0-9._]{8,20}$)(?!.*[_.]{2})[^_.].*[^_.]$"));
    //        return result;
    //    }
    //}
}