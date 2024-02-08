using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoListBooster.DataLayer.PgSql
{
    [Table("doc_task_list")]
    public partial class DocTaskList
    {
        public DocTaskList()
        {
            DocTaskItems = new HashSet<DocTaskItem>();
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
        [Column("user_id")]
        public int UserId { get; set; }
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [ForeignKey("UserId")]
        [InverseProperty("DocTaskLists")]
        public virtual SysUser User { get; set; } = null!;
        [InverseProperty("TaskList")]
        public virtual ICollection<DocTaskItem> DocTaskItems { get; set; }
    }
}
