using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.TaskItemService
{
    public class DeleteTaskItemCommandHandler : IRequestHandler<DeleteTaskItemCommand, int>
    {
        private readonly EfCoreContext _context;
        public DeleteTaskItemCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var taskList = GetById(request.Id);
                _context.TaskItems.Remove(taskList);
                await _context.SaveChangesAsync();
                return request.Id;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при удалении");
            }
        }

        private TaskItem GetById(int id)
        {
            var result = _context.TaskItems.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                throw new ArgumentException($"По запросу такого Id = {id} ничего не найдено");
            }
            else
                return result;
        }
    }
}
