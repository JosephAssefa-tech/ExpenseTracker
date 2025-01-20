using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Models.Categories.Commands;
using ExpenseTrackerApplicationLayer.Models.Categories.Dtos;

namespace ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Categories
{
    public interface  ICategoryService
    {
        Task<bool> CreateCategory(CreateCategoryCommand command);
        Task<bool> UpdateCategory(UpdateCategoryCommand command);
        Task<bool> DeleteCategory(Guid CategoryId);
        Task<List<CategoryDto>> GetAllCategories();
    }
}
