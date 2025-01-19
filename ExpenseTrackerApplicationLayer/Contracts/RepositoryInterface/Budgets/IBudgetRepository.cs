using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Budgets
{
    public interface  IBudgetRepository
    {
        Task<bool> CreateBudget(Budget model);
        Task<List<Budget>> GetAllBudgets();
        Task<bool> UpdateBudget(Budget model);
        Task<bool> DeleteBudget(Guid BudgetId );

    }
}
