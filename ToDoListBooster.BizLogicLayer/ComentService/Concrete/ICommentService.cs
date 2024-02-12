using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core;
using ToDoListBooster.DataLayer.EfClasses;

namespace ToDoListBooster.BizLogicLayer.ComentService
{
    public interface ICommentService : IStatusGeneric
    {
        List<Comment> GetAll(SortFilterDto dto);
        void Create(CreateCommentDto dto);
        void Update(UpdateCommentDto dto);
        void Delete(int id);
    }
}
