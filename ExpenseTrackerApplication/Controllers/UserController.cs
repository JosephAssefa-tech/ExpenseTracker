using AutoMapper;
using ExpenseTrackerApplicationLayer.Models.Users.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTrackerApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("createUser")]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            bool sucess = await _mediator.Send(command);
            return Ok(new { sucess });
        }
    }
}
