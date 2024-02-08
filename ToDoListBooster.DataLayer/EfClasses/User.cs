using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListBooster.DataLayer.EfClasses
{
    [Table("sys_user")]
    public partial class User
    {
        public User()
        {
            TaskLists = new HashSet<TaskList>();
        }

        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Column("user_name")]
        [StringLength(250)]
        public string UserName { get; set; } = null!;
        [Column("password_hash")]
        [StringLength(250)]
        public string PasswordHash { get; set; } = null!;
        [Column("password_salt")]
        [StringLength(250)]
        public string PasswordSalt { get; set; } = null!;
        [Column("email")]
        [StringLength(250)]
        public string Email { get; set; } = null!;
        [Column("created_date", TypeName = "timestamp without time zone")]
        public DateTime CreatedDate { get; set; }

        [InverseProperty(nameof(TaskList.User))]
        public virtual ICollection<TaskList> TaskLists { get; set; }
    }
}
