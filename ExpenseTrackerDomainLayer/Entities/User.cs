using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerDomainLayer.Common.AuditableEntities;
using ExpenseTrackerDomainLayer.Enums;

namespace ExpenseTrackerDomainLayer.Entities
{
    public class User : AuditableEntity
    {
        [Key]
        public Guid UserId { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "User Role is required")]
        public Role Role { get;set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Category> Categories { get; set; }

    }
}
