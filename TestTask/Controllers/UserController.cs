using Application.Tasks.Commands;
using Application.Users.Commands;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateUserCommand command)
        {
            CreateUserCommand s = new CreateUserCommand
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
            };

            var response = await Mediator.Send(s);
            return Ok(response);
        }
    }
}
