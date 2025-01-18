using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Users;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Users;
using ExpenseTrackerApplicationLayer.Models.Users.Commands;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Models.Users.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository,  IMapper mapper) { 
            _userRepository = userRepository;
            _mapper = mapper;
        
        }
        public async Task<bool> CreateUser(CreateUserCommand command)
        {

            var user = _mapper.Map<User>(command);
            return await _userRepository.CreateUser(user);
        }

        public Task<bool> DeleteUser(DeleteUserCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(UpdateUserCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
