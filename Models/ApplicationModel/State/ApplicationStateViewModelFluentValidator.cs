using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.State
{
    public class ApplicationStateViewModelFluentValidator : AbstractValidator<ApplicationStateViewModel>
    {
        public ApplicationStateViewModelFluentValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .Length(1, 100);
            RuleFor(x => x.State)
                .NotEmpty()
                .Length(1, 100);
            RuleFor(x => x.BGColor)
                .NotEmpty()
                .Length(1, 100);

            //.EmailAddress()
            //.MustAsync(async (value, cancellationToken) => await IsUniqueAsync(value));
        }



        private async Task<bool> IsUniqueAsync(string email)
        {
            // Simulates a long running http call
            await Task.Delay(2000);
            return email.ToLower() != "test@test.com";
        }

        public Func<object, string, Task<IEnumerable<string>>> ValidateName => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ApplicationStateViewModel>
                .CreateWithOptions((ApplicationStateViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { "Название не может быть пустым" };
        };

        public Func<object, string, Task<IEnumerable<string>>> ValidateState => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ApplicationStateViewModel>
                .CreateWithOptions((ApplicationStateViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { "Состояние не может быть пустым" };
        };

        public Func<object, string, Task<IEnumerable<string>>> ValidateBGColor => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<ApplicationStateViewModel>
                .CreateWithOptions((ApplicationStateViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { "Выберите цвет" };
        };
    }
}
