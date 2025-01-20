using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Categories;
using ExpenseTrackerApplicationLayer.Models.Categories.Commands;
using MediatR;

namespace ExpenseTrackerApplicationLayer.Models.Categories.CommandHandlers
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {
        private readonly ICategoryService _categoryService;
        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.DeleteCategory(request.CategoryId);
        }
    }
}
