using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Room;

namespace UIBlazor.Models.SharedTablesModel.Validation
{
    public class CreateOrEditRoomFluentValidation : AbstractValidator<CreateOrEditRoomViewModel>
    {
        public CreateOrEditRoomFluentValidation()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(3).WithMessage("Минимальная длина 3 символа")
                .MaximumLength(50).WithMessage("Максильная длина 50 символов");
                //.Must(x => IsValidName(x)).WithMessage("Проверьте правильность ввода, пример: Кабинет №111");
            RuleFor(x => x.Floor)
                .Must(x => IsValidNumber(x.ToString())).WithMessage("В поле могут быть только цифры");
            RuleFor(x => x.CurrentCountSocket)
                .Must(x => IsValidNumber(x.ToString())).WithMessage("В поле могут быть только цифры");
            RuleFor(x => x.RequiredCountSocket)
                .Must(x => IsValidNumber(x.ToString())).WithMessage("В поле могут быть только цифры");
            RuleFor(x => x.Departament)
                .NotNull().WithMessage("Укажите отделение");
            RuleFor(x => x.Building)
                .NotNull().WithMessage("Укажите здание");

        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<CreateOrEditRoomViewModel>
                .CreateWithOptions((CreateOrEditRoomViewModel)model, x => x.IncludeProperties(propertyName)));
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

        private bool IsValidNumber(string text)
        {
            var pattern = "#^[0-9]+$#";
            if (string.IsNullOrWhiteSpace(text))
                return true;

            return !Regex.IsMatch(text, (pattern));
        }
    }
}
