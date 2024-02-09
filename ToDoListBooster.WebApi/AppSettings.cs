using ToDoListBooster.Core.Configurations;
using ToDoListBooster.Core.Security;

namespace ToDoListBooster.WebApi
{
    public class AppSettings
    {
        public static AppSettings Instance { get; private set; } = null!;
        public DatabaseConfig Database { get; set; } = null!;
        public JwtSettings Jwt { get; set; } = null!;
        public SwaggerConfig Swagger { get; set; } = new SwaggerConfig();

        public static void Init(AppSettings instance)
            => Instance = instance;        
    }

    public class SwaggerConfig
    {
        public bool Enabled { get; set; }
    }

}
