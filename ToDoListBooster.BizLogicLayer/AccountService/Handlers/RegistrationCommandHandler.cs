using MediatR;
using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.BizLogicLayer.TaskListService;
using ToDoListBooster.Core.Security;
using ToDoListBooster.DataLayer.EfClasses;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.AccountService
{
    public class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, int>
    {
        private readonly EfCoreContext _context;
        public RegistrationCommandHandler(EfCoreContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(RegistrationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                if(!IsValidUserName(request.UserName))
                {
                    throw new Exception("Такой логин сущществует введите другой логин");
                }

                var newUser = new User()
                {
                    UserName = request.UserName,
                    Email = request.Email
                };
                newUser.SetPassword(request.Password);

                await _context.Users.AddAsync(newUser);
                await _context.SaveChangesAsync();

                return newUser.Id;
            }
            catch (Exception)
            {
                throw new Exception("Такой логин сущществует введите другой логин");
            }
        }

        private bool IsValidUserName(string userName)
        {
            var user = _context.Users.FirstOrDefault(a => a.UserName == userName);
            if(user != null)
            {
                if(user.UserName.Equals(userName))
                    return false;
            }
            return true;
        }
    }
}
