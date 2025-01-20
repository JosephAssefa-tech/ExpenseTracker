using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Categories;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Categories;
using ExpenseTrackerApplicationLayer.Models.Categories.Commands;
using ExpenseTrackerApplicationLayer.Models.Categories.Dtos;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Models.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper) {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        
        }
        public async Task<bool> CreateCategory(CreateCategoryCommand command)
        {
            var category = _mapper.Map<Category>(command);
            return await _categoryRepository.CreateCategory(category);
        }

        public async  Task<bool> DeleteCategory(Guid CategoryId)
        {
            return await _categoryRepository.DeleteCategory(CategoryId);
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {

            var data = await _categoryRepository.GetAllCategories();
           return _mapper.Map<List<CategoryDto>>(data);
        }

        public async Task<bool> UpdateCategory(UpdateCategoryCommand command)
        {
            var category = new Category();
            category.CategoryDescription = command.CategoryDescription;
            category.CategoryName = command.CategoryName;
            category.UserId = command.UserId;
            category.CategoryId = command.CategoryId;
            return await _categoryRepository.UpdateCategory(category);
        }
    }
}
