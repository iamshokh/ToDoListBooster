using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.Core;
using ToDoListBooster.DataLayer.EfClasses;

namespace ToDoListBooster.BizLogicLayer.TaskListService
{
    public class GetAllTaskListQuery : SortFilterDto, IRequest<List<TaskList>>
    {
    }
}
