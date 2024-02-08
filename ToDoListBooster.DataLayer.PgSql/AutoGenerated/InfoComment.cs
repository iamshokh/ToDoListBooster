using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoListBooster.DataLayer.PgSql
{
    [Table("info_comment")]
    public partial class InfoComment
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("tekst")]
        [StringLength(2000)]
        public string Tekst { get; set; } = null!;
        [Column("task_item_id")]
        public int TaskItemId { get; set; }
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("TaskItemId")]
        [InverseProperty("InfoComments")]
        public virtual DocTaskItem TaskItem { get; set; } = null!;
    }
}
