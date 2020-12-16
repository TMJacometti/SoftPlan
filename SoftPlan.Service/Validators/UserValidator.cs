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
                    throw new ArgumentNullException("Objeto não encontrado");
                });

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Necessário informar um email.")
                .NotNull().WithMessage("Necessário informar um email.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Necessário informar um nome.")
                .NotNull().WithMessage("Necessário informar um nome.");
        }
    }
}
