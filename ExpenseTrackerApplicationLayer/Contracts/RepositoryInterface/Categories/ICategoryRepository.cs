using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Categories
{
    public interface ICategoryRepository
    {
        Task<bool> CreateCategory(Category category);
        Task<bool> DeleteCategory(Guid categoryId);
        Task<List<Category>> GetAllCategories();
        Task<bool> UpdateCategory(Category category);
    }
}
