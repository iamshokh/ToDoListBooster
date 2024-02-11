using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.UserService
{
    public interface IUserService : IStatusGeneric
    {
        void Edit(EditUserDto dto, int userId);
    }
}
