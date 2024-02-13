using MediatR;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.TaskListService
{
    public class UpdateTaskListCommandHandler : IRequestHandler<UpdateTaskListCommand, int>
    {
        private readonly EfCoreContext _context;
        public UpdateTaskListCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateTaskListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var updateTaskList = GetById(request.Id);
                updateTaskList.Descrition = request.Descrition;
                updateTaskList.Title = request.Title;
                _context.TaskLists.Update(updateTaskList);
                await _context.SaveChangesAsync();

                return updateTaskList.Id;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при изменении");
            }
        }

        private TaskList GetById(int id)
        {
            var result = _context.TaskLists.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                throw new ArgumentException($"По запросу такого Id = {id} ничего не найдено");
            }
            else
                return result;
        }
    }
}
