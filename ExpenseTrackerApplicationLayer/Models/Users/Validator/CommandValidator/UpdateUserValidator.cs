using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Models.Users.Commands;
using FluentValidation;

namespace ExpenseTrackerApplicationLayer.Models.Users.Validator.CommandValidator
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserValidator() { 
            RuleFor(command => command.UserId).NotNull().WithMessage("UserId is required");

        }
    }
}
