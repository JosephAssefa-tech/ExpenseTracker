using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Categories;
using ExpenseTrackerApplicationLayer.Models.Categories.Dtos;
using ExpenseTrackerApplicationLayer.Models.Categories.Queries;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Categories.QueriesHandlers
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, List<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        public GetAllCategoryQueryHandler(ICategoryService categoryService) {
            _categoryService = categoryService;
        
        }
        public async Task<List<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
           return await _categoryService.GetAllCategories();
        }
    }
}
