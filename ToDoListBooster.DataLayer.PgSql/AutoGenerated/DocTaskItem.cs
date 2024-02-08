using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoListBooster.DataLayer.PgSql
{
    [Table("doc_task_item")]
    public partial class DocTaskItem
    {
        public DocTaskItem()
        {
            InfoComments = new HashSet<InfoComment>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("title")]
        [StringLength(250)]
        public string Title { get; set; } = null!;
        [Column("descrition")]
        [StringLength(2000)]
        public string Descrition { get; set; } = null!;
        [Column("task_list_id")]
        public int TaskListId { get; set; }
        [Column("status_id")]
        public int StatusId { get; set; }
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("StatusId")]
        [InverseProperty("DocTaskItems")]
        public virtual EnumStatus Status { get; set; } = null!;
        [ForeignKey("TaskListId")]
        [InverseProperty("DocTaskItems")]
        public virtual DocTaskList TaskList { get; set; } = null!;
        [InverseProperty("TaskItem")]
        public virtual ICollection<InfoComment> InfoComments { get; set; }
    }
}
