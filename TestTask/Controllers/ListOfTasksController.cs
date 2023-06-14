using Application.ListOfTasks.Commands;
using Application.ListOfTasks.Queries;
using Application.ListOfTasks.Queries.Vm;
using Application.Tasks.Commands;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace TestTask.Controllers
{
    public class ListOfTasksController : ApiController
    {
        [HttpPost]
        public async Task<ActionResult<long>> Create([FromBody] CreateListOfTasksCommand command)
        {
            CreateListOfTasksCommand s = new CreateListOfTasksCommand
            {
                Name = command.Name,
            };

            var response = await Mediator.Send(s);
            return Ok(response);
        }

        [HttpPatch]
        public async Task<ActionResult<long>> Update([FromBody] UpdateListOfTasksCommand command)
        {
            UpdateListOfTasksCommand s = new UpdateListOfTasksCommand
            {
                Name = command.Name,
            };

            var response = await Mediator.Send(s);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<long>> Delete([FromBody] DeleteListOfTaskCommand command)
        {
            DeleteListOfTaskCommand s = new DeleteListOfTaskCommand
            {
               Id = command.Id,
            };

            var response = await Mediator.Send(s);
            return Ok(response);
        }
        
        [HttpGet]
        public async Task<ActionResult<ListOfListOfTasksVM>> GetListOfLists([FromBody] GetListOfListQuery command)
        {
            GetListOfListQuery s = new GetListOfListQuery
            {
                PageSize = command.PageSize,
                StartIndex = command.StartIndex,
            };

            var response = await Mediator.Send(s);
            return Ok(response);
        }

        [HttpGet]
        public async Task<ActionResult<ListOfTask>> GetListById([FromBody] GetListOfTaskByIdQuery command)
        {
            GetListOfTaskByIdQuery s = new GetListOfTaskByIdQuery
            {
                 ListOfTaskId = command.ListOfTaskId,
            };

            var response = await Mediator.Send(s);
            return Ok(response);
        }
    }
}
