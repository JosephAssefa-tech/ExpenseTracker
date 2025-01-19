using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Budgets;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Budgets;
using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using ExpenseTrackerApplicationLayer.Models.Budgets.Queries;
using ExpenseTrackerApplicationLayer.Models.Budgets.ResponseDto;
using ExpenseTrackerDomainLayer.Entities;

namespace ExpenseTrackerApplicationLayer.Models.Budgets.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepository;
        private readonly IMapper _autoMapper;
        public BudgetService(IBudgetRepository budgetRepository, IMapper mapper) { 
            _budgetRepository = budgetRepository;
            _autoMapper = mapper;
        
        }
        public async Task<bool> CreateBudget(CreateBudgetCommand request)
        {
            var budget = _autoMapper.Map<Budget>(request);
           return await _budgetRepository.CreateBudget(budget);
        }

        public async Task<bool> DeleteBudget(DeleteBudgetCommand request)
        {
            return await _budgetRepository.DeleteBudget(request.BudgetId);
        }

        public async Task<List<ListBudgetResponseDto>> GetAllBudgets(GetAllBudgetsQuery query)
        {
           var data = _budgetRepository.GetAllBudgets();
            var result = _autoMapper.Map<List<ListBudgetResponseDto>>(data);
            return result;
        }

        public Task<bool> UpdateBudget(UpdateBudgetCommand request)
        {
            throw new NotImplementedException();
        }
    }
}
