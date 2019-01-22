namespace GP.Aplicacao.DTO
{
    public class SQLConnection
    {
        public string ConnectionString { get; set; }
    }

    public class Logging
    {
        public bool IncludeScopes { get; set; }
        public LogLevelDTO LogLevel { get; set; }
    }

    public class LogLevelDTO
    {
        public string Default { get; set; }
        public string System { get; set; }
        public string Microsoft { get; set; }
    }
}
