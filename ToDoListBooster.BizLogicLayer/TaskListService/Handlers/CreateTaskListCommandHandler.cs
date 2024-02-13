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
    public class CreateTaskListCommandHandler : IRequestHandler<CreateTaskListCommand, int>
    {
        private readonly EfCoreContext _context;
        public CreateTaskListCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTaskListCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newTaskList = new TaskList()
                {
                    Title = request.Title,
                    Descrition = request.Descrition,
                    UserId = request.UserId
                };
                await _context.TaskLists.AddAsync(newTaskList);
                await _context.SaveChangesAsync();

                return newTaskList.Id;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при создании");
            }
        }
    }
}
