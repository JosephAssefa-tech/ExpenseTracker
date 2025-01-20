using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Budgets;
using ExpenseTrackerApplicationPersistance;
using ExpenseTrackerApplicationPersistance.Repositories.Budgets;
using ExpenseTrackerDomainLayer.Entities;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace ExpenseTrackerApplicationIntegrationTest.Repositories
{
    public class BudgetRepositoryIntegrationTests
    {
        private readonly ExpenseTrackerDbContext _expenseTrackerDbContext;
        private readonly IBudgetRepository _budgetRepository;

        public BudgetRepositoryIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<ExpenseTrackerDbContext>().
                UseInMemoryDatabase("IntegratioinTestDb")
                .Options;
            _expenseTrackerDbContext = new ExpenseTrackerDbContext(options);
            _budgetRepository = new BudgetRepository(_expenseTrackerDbContext);
        }
        [Fact]
        public async Task CreateBudget_ShouldAddBudgetToDatabase()
        {
            var budget = new Budget { BudgetName = "Test Budget", Amount = 1000 };

            var result = await _budgetRepository.CreateBudget(budget);

            result.Should().BeTrue();
            _expenseTrackerDbContext.Budgets.Count().Should().Be(1);
        }
        [Fact]
        public async Task CreateBudget_ShouldReturnFalse_WhenBudgetAlreadyExists()
        {
            var budget = new Budget { BudgetName = "Duplicate Budget", Amount = 500 };
            _expenseTrackerDbContext.Budgets.Add(budget);
            await _expenseTrackerDbContext.SaveChangesAsync();

            var result = await _budgetRepository.CreateBudget(budget);

            result.Should().BeFalse();
            _expenseTrackerDbContext.Budgets.Count().Should().Be(1);
        }

    }
}
