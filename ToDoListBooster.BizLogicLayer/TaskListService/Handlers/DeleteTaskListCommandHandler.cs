using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.TaskListService
{
    public class DeleteTaskListCommandHandler : IRequestHandler<DeleteTaskListCommand, int>
    {
        private readonly EfCoreContext _context;
        public DeleteTaskListCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteTaskListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var taskList = GetById(request.Id);
                _context.TaskLists.Remove(taskList);
                await _context.SaveChangesAsync();

                return request.Id;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при удалении");
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
