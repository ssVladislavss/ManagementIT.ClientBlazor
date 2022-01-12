using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Priority
{
    public class ApplicationPrioityViewModelFluentValidator : AbstractValidator<ApplicationPriorityViewModel>
    {
        public ApplicationPrioityViewModelFluentValidator()
        {
            RuleFor(x => x.Name)
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
            var result = await ValidateAsync(ValidationContext<ApplicationPriorityViewModel>
                .CreateWithOptions((ApplicationPriorityViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { "Название не может быть пустым" };
        };
    }
}
