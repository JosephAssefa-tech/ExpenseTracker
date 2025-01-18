using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Models.Users.Commands;
using ExpenseTrackerApplicationLayer.Models.Users.Dtos;
using ExpenseTrackerApplicationLayer.Models.Users.Queries;

namespace ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Users
{
    public interface  IUserService
    {
        Task<bool> CreateUser(CreateUserCommand command);
        Task<bool> UpdateUser(UpdateUserCommand command);
        Task<bool> DeleteUser(DeleteUserCommand command);
        Task<List<UserDto>> GetAllUsers(GetAllUsersQuery request );

    }
}
