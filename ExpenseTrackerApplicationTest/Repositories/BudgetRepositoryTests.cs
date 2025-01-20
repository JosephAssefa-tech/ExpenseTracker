using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationPersistance.Repositories.Budgets;
using ExpenseTrackerApplicationPersistance;
using ExpenseTrackerDomainLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using FluentAssertions;
using System.Linq.Expressions;
using Xunit;

namespace ExpenseTrackerApplicationUnitTest.Repositories
{
    public class BudgetRepositoryTests
    {
        private readonly ExpenseTrackerDbContext _dbContext;
        private readonly BudgetRepository _repository;

        public BudgetRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<ExpenseTrackerDbContext>()
                .UseInMemoryDatabase("TestDatabase")
                .Options;

            _dbContext = new ExpenseTrackerDbContext(options);
            _repository = new BudgetRepository(_dbContext);
        }

        [Fact]
        public async Task CreateBudget_ShouldReturnFalse_WhenBudgetNameExists()
        {
            // Arrange
            _dbContext.Budgets.Add(new Budget { BudgetName = "Test Budget" });
            await _dbContext.SaveChangesAsync();

            var newBudget = new Budget { BudgetName = "Test Budget" };

            // Act
            var result = await _repository.CreateBudget(newBudget);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task CreateBudget_ShouldAddBudgetAndReturnTrue_WhenBudgetNameDoesNotExist()
        {
            // Arrange
            var newBudget = new Budget { BudgetName = "New Budget" };

            // Act
            var result = await _repository.CreateBudget(newBudget);

            // Assert
            result.Should().BeTrue();
            var budget = await _dbContext.Budgets.FirstOrDefaultAsync(b => b.BudgetName == "New Budget");
            budget.Should().NotBeNull();
        }
    }

}
