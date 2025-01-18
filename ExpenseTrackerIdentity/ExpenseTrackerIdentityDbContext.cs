using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerIdentity
{
    //Add-Migration InitialIdentitySchema -Context ExpenseTrackerIdentityDbContext -OutputDir Migrations
    //Update-Database -Context IdentityDbContext

    public class ExpenseTrackerIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ExpenseTrackerIdentityDbContext(DbContextOptions<ExpenseTrackerIdentityDbContext> options)
       : base(options)
        {
        }
    }
}
