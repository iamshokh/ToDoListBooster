using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListBooster.DataLayer.EfClasses
{
    [Table("doc_task_list")]
    public partial class TaskList
    {
        public TaskList()
        {
            TaskItems = new HashSet<TaskItem>();
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

        [ForeignKey(nameof(UserId))]
        [InverseProperty(nameof(EfClasses.User.TaskLists))]
        public virtual User User { get; set; } = null!;
        [InverseProperty(nameof(TaskItem.TaskList))]
        public virtual ICollection<TaskItem> TaskItems { get; set; }
    }
}
