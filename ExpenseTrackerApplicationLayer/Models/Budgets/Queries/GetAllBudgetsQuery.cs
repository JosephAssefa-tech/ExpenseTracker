using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Models.Budgets.ResponseDto;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Budgets.Queries
{
    public class GetAllBudgetsQuery : IRequest<List<ListBudgetResponseDto>>
    {
        public bool? IsDeleted { get; set; }
    }
}
