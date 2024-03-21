using Application.Features.Auth.CQRS.Commands;
using Application.Features.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseApiController
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginUserDto loginDto)
        {
            var command = new LoginUserCommand { LoginUserDto = loginDto };
            return HandleResult(await _mediator.Send(command));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register([FromBody] RegisterUserDto registerDto)
        {
            var command = new RegisterUserCommand { RegisterUserDto = registerDto };
            return HandleResult(await _mediator.Send(command));
        }
    }
}
