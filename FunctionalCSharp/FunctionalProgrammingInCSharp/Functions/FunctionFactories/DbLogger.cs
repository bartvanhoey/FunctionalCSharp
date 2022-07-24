using Dapper;
using Microsoft.Data.SqlClient;
using static FunctionalCSharp.FunctionalProgrammingInCSharp.Functions.FunctionFactories.ConnectionHelper;

namespace FunctionalCSharp.FunctionalProgrammingInCSharp.Functions.FunctionFactories
{
    public class DbLogger
    {
        public string ConnectionString = "connectionString";

        public void Log(LogMessage logMessage)
        {
            using (var conn = new SqlConnection())
            {
                int affectedRows = conn.Execute(("sp_create_Log"), logMessage);
            }
        }

        public IEnumerable<LogMessage> GetLogs(DateTime since)
        {
            var sqlGetLogs = "SELECT * FROM [Logs] WHERE [Timestamp] > @since";

            using (var conn = new SqlConnection())
            {
                return conn.Query<LogMessage>(sqlGetLogs, new { since = since });
            }
        }
        
        public void LogFunctional(LogMessage logMessage) 
            => Connect(ConnectionString, c => c.Execute("sp_create_log", logMessage));

        public IEnumerable<LogMessage> GetLogsFunctional(DateTime since) 
            => Connect(ConnectionString, c => c.Query<LogMessage>("SELECT * FROM [Logs] WHERE [Timestamp] > @since", new{since = since}));
    }
}