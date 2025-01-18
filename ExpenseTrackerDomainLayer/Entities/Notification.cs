using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerDomainLayer.AuditableEntities;

namespace ExpenseTrackerDomainLayer.Entities
{
    public class Notification : AuditableEntity
    {
        [Key]
        public Guid NotificationId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        
    }
}
