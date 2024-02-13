using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.ComentService
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommand, int>
    {
        private readonly EfCoreContext _context;
        public UpdateCommentCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var comment = GetById(request.Id);
                comment.Tekst = request.Tekst;
                _context.Comments.Update(comment);
                await _context.SaveChangesAsync();

                return comment.Id;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при удалении");
            }
        }

        private Comment GetById(int id)
        {
            var result = _context.Comments.FirstOrDefault(a => a.Id == id);
            if (result == null)
            {
                throw new ArgumentException($"По запросу такого Id = {id} ничего не найдено");
            }
            else
                return result;
        }
    }
}
