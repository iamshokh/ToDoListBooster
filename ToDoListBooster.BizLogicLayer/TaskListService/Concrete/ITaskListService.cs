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
        public List<TaskList> GetAll(SortFilterDto dto);
        public void Create(CreateTaskListDto dto);
        public void Update(UpdateTaskListDto dto);
        public void Delete(int id);
    }
}
