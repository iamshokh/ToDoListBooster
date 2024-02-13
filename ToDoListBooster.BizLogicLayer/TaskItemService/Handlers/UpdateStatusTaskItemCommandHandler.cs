using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.TaskItemService
{
    public class UpdateStatusTaskItemCommandHandler : IRequestHandler<UpdateStatusTaskItemCommand, int>
    {
        private readonly EfCoreContext _context;
        public UpdateStatusTaskItemCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateStatusTaskItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var taskItem = GetById(request.Id);
                taskItem.StatusId = request.StatusId;
                _context.TaskItems.Update(taskItem);
                await _context.SaveChangesAsync();

                return taskItem.StatusId;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при изменении статуса");
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
