using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.TaskItemService
{
    public class CreateTaskItemCommandHandler : IRequestHandler<CreateTaskItemCommand, int>
    {
        private readonly EfCoreContext _context;
        public CreateTaskItemCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newTaskList = new TaskItem()
                {
                    Title = request.Title,
                    Descrition = request.Descrition,
                    TaskListId = request.TaskListId,
                    StatusId = StatusIdConst.PENDING
                };
                await _context.TaskItems.AddAsync(newTaskList);
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
