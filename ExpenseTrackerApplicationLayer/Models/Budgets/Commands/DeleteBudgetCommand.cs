using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Budgets.Commands
{
    public class DeleteBudgetCommand : IRequest<bool>
    {
        public Guid BudgetId { get; set; }
    }
}
