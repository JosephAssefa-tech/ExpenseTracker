using ExpenseTrackerApplicationLayer.Models.Budgets.Commands;
using ExpenseTrackerApplicationLayer.Models.Budgets.Queries;
using ExpenseTrackerApplicationLayer.Models.Budgets.ResponseDto;
using ExpenseTrackerApplicationLayer.Models.Categories.Commands;
using ExpenseTrackerApplicationLayer.Models.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApplication.Controllers.Categories
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public CategoryController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [Authorize(Roles = "Admin")]  // Only accessible by Admin
        [HttpPost("createCategory")]
        public async Task<IActionResult> CreateCategory([FromQuery]  CreateCategoryCommand command)
        {
            bool success = await _mediatR.Send(command);
            return Ok(success);
        }

        [Authorize(Roles = "Admin,Manager")]  // Accessible by Admin and Manager
        [HttpPut("editCategory")]
        public async Task<IActionResult> EditCategory([FromQuery] UpdateCategoryCommand command)
        {
              bool success = await _mediatR.Send(command);
            return Ok();
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("getAllCategories")]
        public async Task<ActionResult<List<ListBudgetResponseDto>>> GetAllCategories([FromQuery] GetAllCategoryQuery query)
        {
            var data = await _mediatR.Send(query);

            return Ok(data);

        }
    }
}
