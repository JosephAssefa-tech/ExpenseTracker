using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Models.Users.Commands;
using FluentValidation;

namespace ExpenseTrackerApplicationLayer.Models.Users.Validator.CommandValidator
{
    public class CreateUserValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator() {
            RuleFor(command => command.Email)
         .NotNull().WithMessage("Email is required");

        }
    }
}
