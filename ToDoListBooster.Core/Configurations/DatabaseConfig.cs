namespace ToDoListBooster.Core.Configurations
{
    public class DatabaseConfig
    {
        public PgSqlConfig PgSql { get; set; } = new();
    }

    public class PgSqlConfig
    {
        public string ConnectionString { get; set; } = "";
    }
}
