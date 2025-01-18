using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackerDomainLayer.Entities
{
    public class Budget
    {
        [Key]
        public Guid BudgetId { get; set; }
        public Guid UserId { get; set; }
        public Guid? CategoryId { get; set; }
        public decimal Amount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }

    }
}
