using Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        private IMediator _mediatr;

        protected IMediator Mediator => _mediatr ??= HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(BaseCommandResponse<T> result)
        {
            if (result == null)
                return NotFound(new BaseCommandResponse<int> { Success = false, Message = "Data not found" });

            if (result.Success && result.Value != null)
                return Ok(result);
            if (result.Success && result.Value == null)
                return NotFound(result);


            return BadRequest(result);
        }
    }
}
