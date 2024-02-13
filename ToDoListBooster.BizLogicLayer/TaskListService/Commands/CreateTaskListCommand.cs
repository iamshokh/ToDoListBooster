using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.TaskListService
{
    public class CreateTaskListCommand : IRequest<int>
    {
        [Required]
        [StringLength(250)]
        public string Title { get; set; }
        [Required]
        [StringLength(2000)]
        public string Descrition { get; set; }
        public int UserId { get; set; }
    }
}
