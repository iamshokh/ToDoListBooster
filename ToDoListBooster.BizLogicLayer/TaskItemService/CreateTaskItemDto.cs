using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.TaskItemService
{
    public class CreateTaskItemDto
    {
        [Required]
        [StringLength(250)]
        public string Title { get; set; } = null!;
        [Required]
        [StringLength(2000)]
        public string Descrition { get; set; } = null!;
        [Required]
        public int TaskListId { get; set; }
    }
}
