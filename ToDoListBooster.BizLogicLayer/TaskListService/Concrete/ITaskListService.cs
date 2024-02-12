using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.Core;
using ToDoListBooster.DataLayer.EfClasses;

namespace ToDoListBooster.BizLogicLayer.TaskListService
{
    public interface ITaskListService : IStatusGeneric
    {
        List<TaskList> GetAll(SortFilterDto dto);
        void Create(CreateTaskListDto dto);
        void Update(UpdateTaskListDto dto);
        void Delete(int id);
    }
}
