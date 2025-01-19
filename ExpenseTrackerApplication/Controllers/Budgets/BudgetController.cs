using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using ExpenseTrackerApplicationLayer.Models.Budgets.Queries;
using ExpenseTrackerApplicationLayer.Models.Budgets.ResponseDto;
using MediatR;
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
        [HttpPost("createBudget")]
        public async Task<IActionResult> GetAllBudgers(CreateBudgetCommand query)
        {
            bool data = await _mediatR.Send(query);

            return Ok(data);

        }

        [HttpGet("getAllBudgets")]
        public async Task<ActionResult<List<ListBudgetResponseDto>>> GetAllBudgers(GetAllBudgetsQuery query)
        {
            var data = await _mediatR.Send(query);

            return Ok(data);

        }
    }
}
