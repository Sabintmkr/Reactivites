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
    }
}