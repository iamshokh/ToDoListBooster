using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListBooster.DataLayer.EfClasses
{
    [Table("doc_task_item")]
    public partial class TaskItem
    {
        public TaskItem()
        {
            Comments = new HashSet<Comment>();
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
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [ForeignKey(nameof(StatusId))]
        [InverseProperty(nameof(EfClasses.Status.TaskItems))]
        public virtual Status Status { get; set; } = null!;
        [ForeignKey(nameof(TaskListId))]
        [InverseProperty(nameof(EfClasses.TaskList.TaskItems))]
        public virtual TaskList TaskList { get; set; } = null!;
        [InverseProperty(nameof(Comment.TaskItem))]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
