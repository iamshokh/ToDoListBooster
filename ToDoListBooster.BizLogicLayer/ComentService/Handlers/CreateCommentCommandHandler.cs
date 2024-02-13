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
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, int>
    {
        private readonly EfCoreContext _context;
        public CreateCommentCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var newComment = new Comment()
                {
                    Tekst = request.Tekst,
                    TaskItemId = request.TaskItemId
                };
                await _context.Comments.AddAsync(newComment);
                await _context.SaveChangesAsync();

                return newComment.Id;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при создании");
            }
        }
    }
}
