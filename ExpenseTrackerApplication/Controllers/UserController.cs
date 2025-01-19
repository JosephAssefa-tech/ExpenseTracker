using AutoMapper;
using ExpenseTrackerApplicationLayer.Models.Users.Commands;
using ExpenseTrackerApplicationLayer.Models.Users.Dtos;
using ExpenseTrackerApplicationLayer.Models.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
  //  [Authorize]

//    Use[Authorize(Roles = "Admin")] to restrict endpoints to specific roles.
//Use[Authorize(Policy = "PolicyName")] for custom policies.
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createUser")]
       // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            bool sucess = await _mediator.Send(command);
            return Ok(new { sucess });
        }

        [HttpGet("getAllUsers")]
        public async Task<ActionResult<UserDto>> GetALLUsers([FromQuery]  GetAllUsersQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }
    }
}
