using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ToDoListBooster.DataLayer.PgSql
{
    [Table("enum_status")]
    public partial class EnumStatus
    {
        public EnumStatus()
        {
            DocTaskItems = new HashSet<DocTaskItem>();
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

        [InverseProperty("Status")]
        public virtual ICollection<DocTaskItem> DocTaskItems { get; set; }
    }
}
