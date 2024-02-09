using StatusGeneric;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.AccountService
{
    public interface IAccountService : IStatusGeneric
    {
        Task<LoginResponseDto> Login(LoginDto dto);
        Task<LoginResponseDto> Regester(RegistrateDto dto);
    }
}
