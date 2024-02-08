using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListBooster.DataLayer.EfClasses
{
    [Table("enum_status")]
    public partial class Status
    {
        public Status()
        {
            TaskItems = new HashSet<TaskItem>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("code")]
        [StringLength(50)]
        public string? Code { get; set; }
        [Column("short_name")]
        [StringLength(250)]
        public string ShortName { get; set; } = null!;
        [Column("full_name")]
        [StringLength(300)]
        public string FullName { get; set; } = null!;
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [InverseProperty(nameof(TaskItem.Status))]
        public virtual ICollection<TaskItem> TaskItems { get; set; }
    }
}
