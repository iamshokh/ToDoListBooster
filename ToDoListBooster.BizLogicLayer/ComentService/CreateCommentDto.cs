using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListBooster.BizLogicLayer.ComentService
{
    public class CreateCommentDto
    {
        [Required]
        [StringLength(2000)]
        public string Tekst { get; set; } = null!;
        [Required]
        public int TaskItemId { get; set; }
    }
}
