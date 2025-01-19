using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Budgets;
using ExpenseTrackerDomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApplicationPersistance.Repositories.Budgets
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ExpenseTrackerDbContext _dbContexxt;
        public BudgetRepository(ExpenseTrackerDbContext dbContext) {
            _dbContexxt = dbContext;
        
        }
        public async Task<bool> CreateBudget(Budget model)
        {
            var exists = await _dbContexxt.Budgets.AnyAsync(m => m.BudgetName.Equals(model.BudgetName));
            if (exists) {
                return false;
            }
            else
            {
                _dbContexxt.Budgets.Add(model);
                 await _dbContexxt.SaveChangesAsync();
                return true;
            }
     
        }

        public async Task<bool> DeleteBudget(Guid BudgetId )
        {
            var data = await _dbContexxt.Budgets.FirstOrDefaultAsync(m => m.BudgetId == BudgetId);
            if (data!=null)
            {
                data.IsDeleted = true;
                await _dbContexxt.SaveChangesAsync();
                return true;

            }
            else
            {
                return false;
            }
        }

        public async Task<List<Budget>> GetAllBudgets()
        {
            var res = await _dbContexxt.Budgets.ToListAsync();
            return res;
        }

        public Task<bool> UpdateBudget(Budget model)
        {
            throw new NotImplementedException();
        }
    }
}
