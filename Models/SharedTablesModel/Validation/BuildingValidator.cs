﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UIBlazor.Models.SharedTablesModel.Building;

namespace UIBlazor.Models.SharedTablesModel.Validation
{
    public class BuildingValidator : AbstractValidator<BuildingViewModel>
    {
        public BuildingValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(3).WithMessage("Минимальная длина 3 символа")
                .MaximumLength(50).WithMessage("Максильная длина 50 символов");
            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Поле не может быть пустым")
                .MinimumLength(3).WithMessage("Минимальная длина 3 символа")
                .MaximumLength(50).WithMessage("Максильная длина 50 символов");
            RuleFor(x => x.Floor)
                .Must(x => IsValidNumber(x.ToString())).WithMessage("В поле могут быть только цифры");
        }

        public Func<object, string, Task<IEnumerable<string>>> IsValid => async (model, propertyName) =>
        {
            var result = await ValidateAsync(ValidationContext<BuildingViewModel>
                .CreateWithOptions((BuildingViewModel)model, x => x.IncludeProperties(propertyName)));
            if (result.IsValid)
                return Array.Empty<string>();
            return new List<string>() { result.Errors[0].ErrorMessage };
        };

        private bool IsValidNumber(string text)
        {
            var pattern = "#^[0-9]+$#";
            if (string.IsNullOrWhiteSpace(text))
                return true;

            return !Regex.IsMatch(text, (pattern));
        }
    }
}