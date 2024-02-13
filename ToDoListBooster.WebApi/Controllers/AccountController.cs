using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using ToDoListBooster.BizLogicLayer.AccountService;
using ToDoListBooster.BizLogicLayer.ComentService;

namespace ToDoListBooster.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationCommand command)
        {
            var userId = await _mediator.Send(command);
            return Ok(userId);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(user);
        }
    }
}
