using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBooster.BizLogicLayer.AccountService;

namespace ToDoListBooster.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _service;
        public AccountController(IAccountService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Registration([FromBody] RegistrateDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Regester(dto);

                if (_service.IsValid)
                    return Ok(result);
            }

            return ValidationProblem(ModelState);
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = await _service.Login(dto);

                if (_service.IsValid)
                    return Ok(result);
            }

            return ValidationProblem(ModelState);
        }
    }
}
