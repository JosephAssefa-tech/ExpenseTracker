using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerDomainLayer.AuditableEntities;

namespace ExpenseTrackerDomainLayer.Entities
{
    public class Category : AuditableEntity
    {
        public Guid CategoryId { get; set; }

        public Guid? UserId { get; set; }

        [Required(ErrorMessage ="Category name is requried")]
        [MaxLength(100, ErrorMessage ="Category name can't exceed 50 characters")]
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
