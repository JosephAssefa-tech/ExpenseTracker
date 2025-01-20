using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Categories;
using ExpenseTrackerDomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTrackerApplicationPersistance.Repositories.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpenseTrackerDbContext _dbContext;

        public CategoryRepository(ExpenseTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> CreateCategory(Category category)
        {
           var exists = await _dbContext.Categories.AnyAsync(c=>c.CategoryName.Equals(category.CategoryName));
            if(exists)
            {
                return false;
            }
            else
            {
                await _dbContext.Categories.AddAsync(category);
                await _dbContext.SaveChangesAsync();
                return true;
                
            }
        }

        public async Task<bool> DeleteCategory(Guid categoryId)
        {
            var res = await _dbContext.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if (res == null)
            {
                return false;
            }
            else
            {
                res.IsDeleted = true;
                await _dbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<List<Category>> GetAllCategories()
        {
            var res = await _dbContext.Categories.ToListAsync();
            return res;
        }

        public  async Task<bool> UpdateCategory(Category category)
        {
             _dbContext.Categories.Update(category);
            var result = await _dbContext.SaveChangesAsync();
            return result > 0;
        }
    }
}
