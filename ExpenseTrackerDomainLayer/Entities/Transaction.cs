using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerDomainLayer.AuditableEntities;
using ExpenseTrackerDomainLayer.Enums;

namespace ExpenseTrackerDomainLayer.Entities
{
    public class Transaction : AuditableEntity
    {
        [Key]
        public Guid TransactionId { get; set; }
        public Guid UserId { get; set; }
        public TransactionType TransactionType { get; set; }
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }
        public Guid CategoryId { get; set; }
        public string? Descritption { get; set; }
        public User User { get; set; }
        public Category Category { get; set; }

    }
}
