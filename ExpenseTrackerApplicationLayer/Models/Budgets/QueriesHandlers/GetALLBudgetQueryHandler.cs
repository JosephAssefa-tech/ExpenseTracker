using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Budgets;
using ExpenseTrackerApplicationLayer.Models.Budgets.Queries;
using ExpenseTrackerApplicationLayer.Models.Budgets.ResponseDto;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Budgets.QueriesHandlers
{
    public class GetALLBudgetQueryHandler : IRequestHandler<GetAllBudgetsQuery, List<ListBudgetResponseDto>>
    {
        private readonly IBudgetService _budgetService;

        public GetALLBudgetQueryHandler(IBudgetService budgetService)
        {
            _budgetService = budgetService;
        }
        public async Task<List<ListBudgetResponseDto>> Handle(GetAllBudgetsQuery request, CancellationToken cancellationToken)
        {
            return await _budgetService.GetAllBudgets(request);
        }
    }
}
