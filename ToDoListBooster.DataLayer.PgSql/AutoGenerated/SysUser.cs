using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoListBooster.DataLayer.PgSql
{
    [Table("sys_user")]
    public partial class SysUser
    {
        public SysUser()
        {
            DocTaskLists = new HashSet<DocTaskList>();
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

        [InverseProperty("User")]
        public virtual ICollection<DocTaskList> DocTaskLists { get; set; }
    }
}
