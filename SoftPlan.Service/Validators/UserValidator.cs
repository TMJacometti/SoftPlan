using FluentValidation;
using SoftPlan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoftPlan.Service.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Objeto n�o encontrado");
                });

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Necess�rio informar um email.")
                .NotNull().WithMessage("Necess�rio informar um email.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Necess�rio informar um nome.")
                .NotNull().WithMessage("Necess�rio informar um nome.");
        }
    }
}
