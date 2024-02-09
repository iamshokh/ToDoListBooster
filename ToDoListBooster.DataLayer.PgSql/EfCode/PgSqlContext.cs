using Microsoft.EntityFrameworkCore;
using ToDoListBooster.DataLayer.EfCode;

namespace ToDoListBooster.DataLayer.PgSql.EfCode
{
    public partial class PgSqlContext : EfCoreContext
    {
        public PgSqlContext(DbContextOptions<PgSqlContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
