using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using UIBlazor.Models.SharedTablesModel.Employee;

namespace UIBlazor.Models.SharedTablesModel.Validation
{
    public class CreateOrEditEmployeeFluentValidator : AbstractValidator<CreateOrEditEmployeeViewModel>
    {
        public CreateOrEditEmployeeFluentValidator()
        {
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(3).WithMessage("Минимальная длина имени 3 символа")
                .MaximumLength(50).WithMessage("Максильная длина имени 50 символов")
                .Must(x => IsValidName(x)).WithMessage("Проверьте правильность ввода, пример: Королёв");
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(3).WithMessage("Минимальная длина имени 3 символа")
                .MaximumLength(50).WithMessage("Максильная длина имени 50 символов")
                .Must(x => IsValidName(x)).WithMessage("Проверьте правильность ввода, пример: Владислав");
            RuleFor(x => x.Departament)
                .NotNull().WithMessage("Укажите отделение");
            RuleFor(x => x.Patronymic)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(3).WithMessage("Минимальная длина имени 3 символа")
                .MaximumLength(50).WithMessage("Максильная длина имени 50 символов")
                .Must(x => IsValidName(x)).WithMessage("Проверьте правильность ввода, пример: Владислав");
            RuleFor(x => x.Position)
                .NotNull().WithMessage("Укажите должность");
            RuleFor(x => x.Mail)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .EmailAddress().WithMessage("Email не валиден, пример: example@mail.ru");
            RuleFor(x => x.MobileTelephone)
                .MaximumLength(20).WithMessage("Максильная длина мобильного телефона 20 символов")
                .Must(x => IsValidMobileTelephone(x)).WithMessage("Номер не валиден, пример: 8-999-111-22-33");
            RuleFor(x => x.WorkTelephone)
            .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(10).WithMessage("Минимальная длина телефона 10 символов")
                .MaximumLength(20).WithMessage("Максильная длина телефона 20 символов")
                .Must(x => IsValidTelephone(x)).WithMessage("Номер не валиден, пример: 8-999-111-22-33");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<CreateOrEditEmployeeViewModel>
                .CreateWithOptions((CreateOrEditEmployeeViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };

        private bool IsValidName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return false;
            return !Regex.IsMatch(name, ("^.*[^A-zА-яЁё].*$"));
        }

        private bool IsValidTelephone(string telephone)
        {
            if (string.IsNullOrEmpty(telephone))
                return true;
            var charDigit = Regex.IsMatch(telephone, ("^.*[^A-zА-яЁё].*$"));
            var result = Regex.IsMatch(telephone, (@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"));
            if (!charDigit)
                return charDigit;
            return result;
        }

        private bool IsValidMobileTelephone(string telephone)
        {
            if (string.IsNullOrEmpty(telephone))
                return true;
            if (telephone == "+7 " || telephone == "+7") return true;
            var charDigit = Regex.IsMatch(telephone, ("^.*[^A-zА-яЁё].*$"));
            var result = Regex.IsMatch(telephone, (@"^((8|\+7)[\- ]?)?(\(?\d{3}\)?[\- ]?)?[\d\- ]{7,10}$"));
            if (!charDigit)
                return charDigit;
            return result;
        }
    }
}