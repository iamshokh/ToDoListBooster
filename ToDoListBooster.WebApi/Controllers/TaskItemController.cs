using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBooster.BizLogicLayer.ComentService;
using ToDoListBooster.BizLogicLayer.TaskItemService;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core;

namespace ToDoListBooster.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TaskItemController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskItemController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskItemCommand command)
        {
            var taskItemId = await _mediator.Send(command);
            return Ok(taskItemId);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTaskItemCommand command)
        {
            var taskItemId = await _mediator.Send(command);
            return Ok(taskItemId);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(UpdateStatusTaskItemCommand command)
        {
            var taskItemId = await _mediator.Send(command);
            return Ok(taskItemId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTaskItemQuery command)
        {
            var taskItems = await _mediator.Send(command);
            return Ok(taskItems);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteTaskItemCommand command)
        {
            var taskItemId = await _mediator.Send(command);
            return Ok(taskItemId);
        }
    }
}
