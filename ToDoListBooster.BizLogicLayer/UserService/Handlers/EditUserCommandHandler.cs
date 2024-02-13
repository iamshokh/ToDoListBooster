using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.UserService
{
    public class EditUserCommandHandler : IRequestHandler<EditUserCommand, int>
    {
        private readonly EfCoreContext _context;
        public EditUserCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(a => a.Id == request.Id);
                if (user != null)
                {
                    user.Email = request.Email;
                    user.UserName = request.UserName;

                    await _context.SaveChangesAsync();
                    return request.Id;
                }

                return int.MaxValue;
            }
            catch (Exception)
            {
                throw new Exception("Ошибка при изменении");
            }
        }
    }
}
