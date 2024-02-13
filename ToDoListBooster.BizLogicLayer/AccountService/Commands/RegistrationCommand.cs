using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.AccountService
{
    public class RegistrationCommand : IRequest<int>
    {
        [Required]
        [StringLength(250)]
        public string UserName { get; set; }
        [Required]
        [StringLength(250)]
        public string Email { get; set; }
        [Required]
        [StringLength(250)]
        //[DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
        ErrorMessage = "Пароль должен иметь длину не менее 8 символов и содержать хотя бы одну заглавную букву, одну строчную букву, одну цифру и один специальный символ.")]
        public string Password { get; set; }
    }
}
