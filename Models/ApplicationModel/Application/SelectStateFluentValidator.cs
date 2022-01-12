﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UIBlazor.Models.ApplicationModel.Application
{
    public class SelectStateFluentValidator : AbstractValidator<SelectedStateViewModel>
    {
        public SelectStateFluentValidator()
        {
            RuleFor(x => x.State)
                .NotNull().WithMessage("Выберите состояние заявки");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<SelectedStateViewModel>
                .CreateWithOptions((SelectedStateViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };
    }
}
