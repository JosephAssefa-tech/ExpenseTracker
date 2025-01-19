using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Budgets.Commands
{
    public class CreateBudgetCommand : IRequest <bool>
    {

        public Guid UserId { get; set; }
        public Guid? CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }
        public string? BudgetName { get; set; }
    }
}
