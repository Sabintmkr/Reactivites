using Application.Core;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        //private means can be used only in this class
        //protected means can be used in this class and other derived classes that are using this class.
        private IMediator _mediator;

        protected IMediator Mediator => _mediator ??=
             HttpContext.RequestServices.GetService<IMediator>();

        protected ActionResult HandleResult<T>(Result<T> result)
        {
            if(result == null) return NotFound();
            
            if(result.IsSuccess && result.Value != null)
                return Ok(result.Value);
            
            if(result.IsSuccess && result.Value == null)
                return NotFound();

            return BadRequest(result.Error);
        }
    }
}