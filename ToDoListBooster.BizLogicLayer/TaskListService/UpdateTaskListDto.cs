using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.TaskListService
{
    public class UpdateTaskListDto : CreateTaskListDto
    {
        [Required]
        public int Id { get; set; }
    }
}
