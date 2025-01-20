using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<bool>
    {
        public Guid? UserId { get; set; }

        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
    }

}
