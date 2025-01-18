using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Users
{
    public interface  IUserRepository
    {
        Task<bool> CreateUser(User model);
        Task<bool> UpdateUser(User model);
        Task<bool> DeleteUser(int userId);
        Task<List<User>> GetAllUsers(int? userId);
    }
}
