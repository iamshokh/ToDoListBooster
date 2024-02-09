using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.AccountService
{
    public class LoginDto
    {
        public string NameOrEmail { get; set; }
        public string Password { get; set; }
    }
}
