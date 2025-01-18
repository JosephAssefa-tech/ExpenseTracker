using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ExpenseTrackerIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = "jojo";
        public DateTime? DateOfBirth { get; set; }
        public string ProfilePictureUrl { get; set; } = "jojo";



    }
}
