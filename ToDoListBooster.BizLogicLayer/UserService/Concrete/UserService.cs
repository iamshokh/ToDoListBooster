using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.BizLogicLayer.UserService
{
    public class UserService : StatusGenericHandler, IUserService
    {
        private readonly EfCoreContext _context;
        public UserService(EfCoreContext context)
        {
            _context = context;
        }

        public void Edit(EditUserDto dto, int userId)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(a => a.Id == userId);
                if (user != null)
                {
                    user.Email = dto.Email;
                    user.UserName = dto.UserName;

                    _context.SaveChanges();
                    return;
                }
                AddError("Не существует такого Юсера");
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
