using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBooster.BizLogicLayer.AccountService;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core;

namespace ToDoListBooster.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskListService _service;
        public TaskListController(ITaskListService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll([FromBody] SortFilterDto dto)
        {
            if (ModelState.IsValid)
            {
                var result = _service.GetAll(dto);

                if (_service.IsValid)
                    return Ok(result);
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateTaskListDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Create(dto);

                if (_service.IsValid)
                    return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        public IActionResult Update([FromBody] UpdateTaskListDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Update(dto);

                if (_service.IsValid)
                    return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                _service.Delete(id);

                if (_service.IsValid)
                    return Ok();
            }
            return ValidationProblem(ModelState);
        }
    }
}
