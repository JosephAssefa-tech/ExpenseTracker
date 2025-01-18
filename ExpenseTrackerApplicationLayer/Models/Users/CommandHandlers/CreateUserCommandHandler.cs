using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Users;
using ExpenseTrackerApplicationLayer.Models.Users.Commands;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Users.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IUserService _userService;
        public CreateUserCommandHandler(IUserService userService) {
            _userService = userService;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _userService.CreateUser(request);
        }
    }
}
