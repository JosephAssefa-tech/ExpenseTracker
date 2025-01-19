using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using ExpenseTrackerApplicationLayer.Models.Budgets.Queries;
using ExpenseTrackerApplicationLayer.Models.Budgets.ResponseDto;

namespace ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Budgets
{
    public interface IBudgetService
    {
        Task<bool> CreateBudget(CreateBudgetCommand request);
        Task<bool> UpdateBudget(UpdateBudgetCommand request);
        Task<bool> DeleteBudget(DeleteBudgetCommand request);
        Task<List<ListBudgetResponseDto>> GetAllBudgets(GetAllBudgetsQuery query);
    }
}
