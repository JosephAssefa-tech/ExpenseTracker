using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Models.Categories.Dtos;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Categories.Queries
{
    public class GetAllCategoryQuery : IRequest<List<CategoryDto>>
    {
    }
}
