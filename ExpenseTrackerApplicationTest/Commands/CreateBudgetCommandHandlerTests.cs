using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ExpenseTrackerApplicationLayer.Contracts.ServiceInterface.Budgets;
using ExpenseTrackerApplicationLayer.Models.Budgets.CommandHandlers;
using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using FluentAssertions;
using Moq;
using Xunit;

namespace ExpenseTrackerApplicationUnitTest.Commands
{
    public class CreateBudgetCommandHandlerTests
    {
        private readonly Mock<IBudgetService> _mockBudgetService;
        private readonly CreateBudgetCommandHandler _createBudgetCommandHandler;

        public CreateBudgetCommandHandlerTests(Mock<IBudgetService> mockBudgetService, CreateBudgetCommandHandler createBudgetCommandHandler)
        {
            _mockBudgetService = mockBudgetService;
            _createBudgetCommandHandler = createBudgetCommandHandler;
        }
        [Fact]
        public async Task Handle_ShouldReturnTrueWhenBudgetIsCreated()
        {
            var command = new CreateBudgetCommand { BudgetName = "TestBudget", Amount = 1000 };

            _mockBudgetService.Setup(s=>s.CreateBudget(command)).ReturnsAsync(true);
            var result = await _createBudgetCommandHandler.Handle(command, CancellationToken.None);


            result.Should().BeTrue();
            _mockBudgetService.Verify(s => s.CreateBudget(It.IsAny<CreateBudgetCommand>()), Times.Once);


        }

        [Fact]
        public async Task Handle_ShouldReturnFalse_WhenBudgetAlreadyExists()
        {
            var command = new CreateBudgetCommand { BudgetName = "TestBudget", Amount = 1000 };
            _mockBudgetService.Setup(s => s.CreateBudget(command)).ReturnsAsync(false);

            var result = await _createBudgetCommandHandler.Handle(command, CancellationToken.None);

            result.Should().BeFalse();
            _mockBudgetService.Verify(s => s.CreateBudget(It.IsAny<CreateBudgetCommand>()), Times.Once);
        }
    }
}
