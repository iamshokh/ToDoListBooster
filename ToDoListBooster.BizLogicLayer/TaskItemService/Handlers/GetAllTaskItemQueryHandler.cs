using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class GetAllTaskItemQueryHandler : IRequestHandler<GetAllTaskItemQuery, List<TaskItem>>
    {
        private readonly EfCoreContext _context;
        public GetAllTaskItemQueryHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<List<TaskItem>> Handle(GetAllTaskItemQuery request, CancellationToken cancellationToken)
        {
            var result = await SortFilter(request);
            return result;
        }

        private async Task<List<TaskItem>> SortFilter(SortFilterDto dto)
        {
            var result = await _context.TaskItems.Include(a => a.TaskList)
                                           .Include(a => a.Comments)
                                           .Include(a => a.Status)
                                           .OrderBy(p => p.Id).ToListAsync();

            if (!string.IsNullOrEmpty(dto.Search))
                result = result.Where(a => a.Title.ToLower().Contains(dto.Search.ToLower()) ||
                                           a.Descrition.ToLower().Contains(dto.Search.ToLower())).ToList();

            if (dto.Limit.HasValue && dto.Page.HasValue)
            {
                result = result.Skip(((dto.Page ?? 1) - 1) * dto.Limit ?? 10)
                                              .Take(dto.Limit ?? 10)
                                              .ToList();
            }

            return result;
        }
    }
}
