using Microsoft.EntityFrameworkCore;

namespace ToDoListBooster.DataLayer.EfCode
{
    public class EfCoreContext : DbContext
    {
        public EfCoreContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
