using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBooster.BizLogicLayer.ComentService;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core;

namespace ToDoListBooster.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CommentController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CommentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCommentCommand command)
        {
            var commentId = await _mediator.Send(command);
            return Ok(commentId);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCommentCommand command)
        {
            var commentId = await _mediator.Send(command);
            return Ok(commentId);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllCommentQuery command)
        {
            var comments = await _mediator.Send(command);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(DeleteCommentCommand command)
        {
            var commentId = await _mediator.Send(command);
            return Ok(commentId);
        }
    }
}
