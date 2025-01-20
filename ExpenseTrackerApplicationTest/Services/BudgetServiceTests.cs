using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Contracts.RepositoryInterface.Budgets;
using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using ExpenseTrackerApplicationLayer.Models.Budgets.Services;
using ExpenseTrackerDomainLayer.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace ExpenseTrackerApplicationUnitTest.Services
{
    public class BudgetServiceTests
    {
        private readonly Mock<IBudgetRepository> _budgetRepositoryMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BudgetService _service;

        public BudgetServiceTests()
        {
            _budgetRepositoryMock = new Mock<IBudgetRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new BudgetService(_budgetRepositoryMock.Object, _mapperMock.Object);


        }
        [Fact]
        public async Task CreateBudget_ShouldReturnTrue_WhenRepositoryCreatesBudget()
        {
            var command = new CreateBudgetCommand { BudgetName = "New Budget", Amount = 1500 };
            var budget = new Budget { BudgetName = "New Budget", Amount = 1500 };

            _mapperMock.Setup(m => m.Map<Budget>(command)).Returns(budget);
            _budgetRepositoryMock.Setup(r => r.CreateBudget(budget)).ReturnsAsync(true);

            var result = await _service.CreateBudget(command);

            result.Should().BeTrue();
            _mapperMock.Verify(m => m.Map<Budget>(It.IsAny<CreateBudgetCommand>()), Times.Once);
            _budgetRepositoryMock.Verify(r => r.CreateBudget(It.IsAny<Budget>()), Times.Once);
        }

    }
}
