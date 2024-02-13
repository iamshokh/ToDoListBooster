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

namespace ToDoListBooster.BizLogicLayer.ComentService
{
    public class GetAllCommentQueryHandler : IRequestHandler<GetAllCommentQuery, List<Comment>>
    {
        private readonly EfCoreContext _context;
        public GetAllCommentQueryHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Comment>> Handle(GetAllCommentQuery request, CancellationToken cancellationToken)
        {
            var result = await SortFilter(request);
            return result;
        }

        private async Task<List<Comment>> SortFilter(SortFilterDto dto)
        {
            var result = await _context.Comments.Include(a => a.Tekst)
                                          .Include(a => a.TaskItem)
                                          .OrderBy(p => p.Id).ToListAsync();

            if (!string.IsNullOrEmpty(dto.Search))
                result = result.Where(a => a.Tekst.ToLower().Contains(dto.Search.ToLower())).ToList();

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
