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
    public class UpdateTaskItemCommandHandler : IRequestHandler<UpdateTaskItemCommand, int>
    {
        private readonly EfCoreContext _context;
        public UpdateTaskItemCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updateTaskItem = GetById(request.Id);
                updateTaskItem.Descrition = request.Descrition;
                updateTaskItem.Title = request.Title;
                _context.TaskItems.Update(updateTaskItem);
                await _context.SaveChangesAsync();

                return updateTaskItem.Id;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при изменении");
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
