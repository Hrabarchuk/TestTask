using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private IMediator? _mediator;
        protected ISender Mediator => _mediator = HttpContext.RequestServices.GetService<IMediator>();
    }
}
