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
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
    {
        private readonly IMediator _mediator;
        private readonly ICategoryService _categoryService;
        public CreateCategoryCommandHandler(IMediator mediator, ICategoryService categoryService)
        {
            _mediator = mediator;
            _categoryService = categoryService;
        }
        public async Task<bool> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            return await _categoryService.CreateCategory(request);
        }
    }
}
