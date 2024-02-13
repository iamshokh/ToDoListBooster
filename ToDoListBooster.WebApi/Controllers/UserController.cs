using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoListBooster.BizLogicLayer.AccountService;
using ToDoListBooster.BizLogicLayer.UserService;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator, EfCoreContext context)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(EditUserCommand command)
        {
            command.Id =  Convert.ToInt32(HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }
    }
}
