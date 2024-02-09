using Microsoft.EntityFrameworkCore;
using ToDoListBooster.DataLayer.EfCode;
using ToDoListBooster.DataLayer.PgSql.EfCode;

namespace ToDoListBooster.WebApi.Extensions
{
    public static class DbServiceExtentions
    {
        public static void ConfigureDbServices(this IServiceCollection services)
        {
            services.AddDbContext<EfCoreContext, PgSqlContext>(options =>
                options.UseNpgsql(AppSettings.Instance.Database.PgSql.ConnectionString));
                       //.AddInterceptors(new HintInterceptor()));
            services.AddScoped<DbContext>(x => x.GetService<EfCoreContext>());
        }
    }
}
