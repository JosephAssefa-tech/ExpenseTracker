using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using ExpenseTrackerApplicationLayer.Models.Budgets.Queries;
using ExpenseTrackerApplicationLayer.Models.Budgets.ResponseDto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApplication.Controllers.Budgets
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public BudgetController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }
        [Authorize(Roles = "Admin")]  // Only accessible by Admin
        [HttpPost("createBudget")]
        public async Task<IActionResult> CreateBudget(CreateBudgetCommand command)
        {
            bool success = await _mediatR.Send(command);
            return Ok(success);
        }

        [Authorize(Roles = "Admin,Manager")]  // Accessible by Admin and Manager
        [HttpPost("editBudget")]
        public async Task<IActionResult> EditBudget( )
        {
         //   bool success = await _mediatR.Send();
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getAllBudgets")]
        public async Task<ActionResult<List<ListBudgetResponseDto>>> GetAllBudgers([FromQuery]  GetAllBudgetsQuery query)
        {
            var data = await _mediatR.Send(query);

            return Ok(data);

        }
    }
}
