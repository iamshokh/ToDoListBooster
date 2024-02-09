using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ToDoListBooster.Core.Security;

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

        public bool IsValidPassword(string password)
        {
            return !(string.IsNullOrEmpty(password) || PasswordHasher.GenerateHash(password, PasswordSalt) != PasswordHash);
        }
        public void SetPassword(string password, bool isNewEntity = false)
        {
            if (isNewEntity && string.IsNullOrEmpty(password))
                throw new ArgumentException("Пароль требуется для нового пользователя", nameof(password));

            if (isNewEntity || !string.IsNullOrEmpty(password))
            {
                PasswordSalt = PasswordHasher.GenerateSalt();
                PasswordHash = PasswordHasher.GenerateHash(password, PasswordSalt);
            }
        }
    }
}
