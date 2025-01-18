using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Users;
using ExpenseTrackerDomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApplicationPersistance.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseTrackerDbContext _context;
        public UserRepository(ExpenseTrackerDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateUser(User model)
        {
            try
            {
                var exists = await _context.Users.AnyAsync(m=>m.Email.Equals(model.Email));
                if (exists)
                {
                    return false;
                }
                 _context.Users.Add(model);
                await _context.SaveChangesAsync();


                return true;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
         
        }

        public Task<bool> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllUsers(int? userId)
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }

        public Task<bool> UpdateUser(User model)
        {
            throw new NotImplementedException();
        }
    }
}
