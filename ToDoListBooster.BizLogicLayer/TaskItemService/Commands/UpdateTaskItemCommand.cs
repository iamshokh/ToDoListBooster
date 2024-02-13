using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.TaskItemService
{
    public class UpdateTaskItemCommand : CreateTaskItemCommand
    {
        [Required]
        public int Id { get; set; }
    }
}
