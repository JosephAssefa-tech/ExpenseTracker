using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using ExpenseTrackerApplicationLayer.Models.Budgets.Services;
using ExpenseTrackerApplicationPersistance.Repositories.Budgets;
using ExpenseTrackerApplicationPersistance;
using Microsoft.EntityFrameworkCore;
using Xunit;
using FluentAssertions;
using ExpenseTrackerApplicationLayer.Models.Budgets.AutoMapper;

namespace ExpenseTrackerApplicationIntegrationTest.Services
{
    public class BudgetServiceIntegrationTests : IDisposable
    {
        private readonly ExpenseTrackerDbContext _context;
        private readonly BudgetService _service;

        public BudgetServiceIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<ExpenseTrackerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()) // Unique database for each test
                .Options;

            _context = new ExpenseTrackerDbContext(options);
            var repository = new BudgetRepository(_context);
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile(new BudgetMappingProfile())).CreateMapper();

            _service = new BudgetService(repository, mapper);
        }

        [Fact]
        public async Task CreateBudget_ShouldSaveBudgetToDatabase()
        {
            // Arrange
            var command = new CreateBudgetCommand { BudgetName = "Service Test Budget", Amount = 2000 };

            // Act
            var result = await _service.CreateBudget(command);

            // Assert
            result.Should().BeTrue();
            _context.Budgets.Count().Should().Be(1);
            _context.Budgets.First().BudgetName.Should().Be("Service Test Budget");
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }

}
