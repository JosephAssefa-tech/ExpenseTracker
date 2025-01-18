using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Users;
using ExpenseTrackerApplicationLayer.Models.Users.Dtos;
using ExpenseTrackerApplicationLayer.Models.Users.Queries;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Users.QueriesHandlers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public GetAllUsersQueryHandler(IMapper mapper, IUserService userService) { 
            _mapper = mapper;
            _userService = userService;
        
        }
        public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAllUsers(request);
        }
    }
}
