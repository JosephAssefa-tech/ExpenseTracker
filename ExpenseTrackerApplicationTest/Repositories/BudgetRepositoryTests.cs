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
        private readonly Mock<ExpenseTrackerDbContext> _dbContextMock;
        private readonly Mock<DbSet<Budget>> _budgetDbSetMock;
        private readonly BudgetRepository _repository;

        public BudgetRepositoryTests()
        {
            _dbContextMock = new Mock<ExpenseTrackerDbContext>();
            _budgetDbSetMock = new Mock<DbSet<Budget>>();

            _dbContextMock.Setup(m => m.Budgets).Returns(_budgetDbSetMock.Object);

            _repository = new BudgetRepository(_dbContextMock.Object);
        }
        [Fact]
        public async Task CreateBudget_ShouldReturnFalse_WhenBudgetNameExists()
        {
            // Arrange
            var existingBudget = new Budget { BudgetName = "Test Budget" };
            var newBudget = new Budget { BudgetName = "Test Budget" };

            _budgetDbSetMock.Setup(m => m.AnyAsync(It.IsAny<Expression<Func<Budget, bool>>>(), default))
                .ReturnsAsync(true);

            // Act
            var result = await _repository.CreateBudget(newBudget);

            // Assert
            result.Should().BeFalse();
            _budgetDbSetMock.Verify(m => m.Add(It.IsAny<Budget>()), Times.Never);
            _dbContextMock.Verify(m => m.SaveChangesAsync(default), Times.Never);
        }

        [Fact]
        public async Task CreateBudget_ShouldAddBudgetAndReturnTrue_WhenBudgetNameDoesNotExist()
        {
            // Arrange
            var newBudget = new Budget { BudgetName = "New Budget" };

            _budgetDbSetMock.Setup(m => m.AnyAsync(It.IsAny<Expression<Func<Budget, bool>>>(), default))
                .ReturnsAsync(false);

            // Act
            var result = await _repository.CreateBudget(newBudget);

            // Assert
            result.Should().BeTrue();
            _budgetDbSetMock.Verify(m => m.Add(It.IsAny<Budget>()), Times.Once);
            _dbContextMock.Verify(m => m.SaveChangesAsync(default), Times.Once);
        }
    }
}
