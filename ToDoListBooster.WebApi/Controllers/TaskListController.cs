using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoListBooster.BizLogicLayer.AccountService;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core;

namespace ToDoListBooster.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class TaskListController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TaskListController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTaskListCommand command)
        {
            command.UserId = CurrentUserId();
            var taskListId = await _mediator.Send(command);
            return Ok(taskListId);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateTaskListCommand command)
        {
            var taskListId = await _mediator.Send(command);
            return Ok(taskListId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllTaskListQuery command)
        {
            var taskLists = await _mediator.Send(command);
            return Ok(taskLists);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteTaskListCommand command)
        {
            var taskListId = await _mediator.Send(command);
            return Ok(taskListId);
        }

        private int CurrentUserId()
        {
            var currentUser = HttpContext.User;
            var userId = currentUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Convert.ToInt32(userId);
        }
    }
}
