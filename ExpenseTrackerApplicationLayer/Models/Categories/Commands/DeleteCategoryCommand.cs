using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Categories.Commands
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid CategoryId { get; set; }
    }
}
