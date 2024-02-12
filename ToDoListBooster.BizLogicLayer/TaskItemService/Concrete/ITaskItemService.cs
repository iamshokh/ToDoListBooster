using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core;
using ToDoListBooster.DataLayer.EfClasses;

namespace ToDoListBooster.BizLogicLayer.TaskItemService
{
    public interface ITaskItemService : IStatusGeneric
    {
        List<TaskItem> GetAll(SortFilterDto dto);
        void Create(CreateTaskItemDto dto);
        void Update(UpdateTaskItemDto dto);
        void UpdateStatus(UpdateStatusTaskItemDto dto);
        void Delete(int id);
    }
}
