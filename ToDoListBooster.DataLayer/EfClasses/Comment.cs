using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListBooster.DataLayer.EfClasses
{
    [Table("info_comment")]
    public partial class Comment
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

        [ForeignKey(nameof(TaskItemId))]
        [InverseProperty(nameof(EfClasses.TaskItem.Comments))]
        public virtual TaskItem TaskItem { get; set; } = null!;
    }
}
