using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoListBooster.BizLogicLayer.TaskItemService;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core;

namespace ToDoListBooster.WebApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TaskItemController : ControllerBase
    {
        private readonly ITaskItemService _service;
        public TaskItemController(ITaskItemService service)
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
        public IActionResult Create([FromBody] CreateTaskItemDto dto)
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
        public IActionResult Update([FromBody] UpdateTaskItemDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.Update(dto);

                if (_service.IsValid)
                    return Ok();
            }
            return ValidationProblem(ModelState);
        }

        [HttpPost]
        public IActionResult UpdateStatus([FromBody] UpdateStatusTaskItemDto dto)
        {
            if (ModelState.IsValid)
            {
                _service.UpdateStatus(dto);

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
