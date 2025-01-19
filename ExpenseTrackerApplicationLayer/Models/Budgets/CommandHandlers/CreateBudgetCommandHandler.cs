using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Budgets;
using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Budgets.CommandHandlers
{
    public class CreateBudgetCommandHandler : IRequestHandler<CreateBudgetCommand, bool>
    {
        private readonly IBudgetService _budgetService;
        public CreateBudgetCommandHandler(IBudgetService budgetService) { 
            _budgetService = budgetService;
        
        }
        public async Task<bool> Handle(CreateBudgetCommand request, CancellationToken cancellationToken)
        {
            return await _budgetService.CreateBudget(request);
        }
    }
}
