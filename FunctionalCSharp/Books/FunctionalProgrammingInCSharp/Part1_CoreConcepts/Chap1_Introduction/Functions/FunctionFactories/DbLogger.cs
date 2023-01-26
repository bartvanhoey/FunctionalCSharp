using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using static System.Data.CommandType;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction.Functions.FunctionFactories.ConnectionHelper;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction.Functions.FunctionFactories
{
    public class DbLogger
    {
        private const string ConnectionString = "connectionString";
        private const string SelectFromLogsSinceSql = "SELECT * FROM [Logs] WHERE [Timestamp] > @since";
        
        // Initial implementation
        public void Log(LogMessage message)
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            conn.Execute("sp_create_Log", message, commandType: StoredProcedure);
        }
        
        
        public int LogFp(LogMessage message) 
            => Connect(ConnectionString, conn => conn.Execute("sp_create_log", message, commandType: StoredProcedure) );
        
        public IEnumerable<LogMessage> GetLogsFp(DateTime since) 
            => Connect(ConnectionString, conn => conn.Query<LogMessage>(SelectFromLogsSinceSql, new {since = since}) );


        // functional implementation
        public void LogFunctional(LogMessage message) 
            => Connect(ConnectionString, conn => conn.Execute("sp_create_log", message, commandType: StoredProcedure));
        
        // Benefits of using HOFs that takes a function as an argument
        // 1. Conciseness - the bigger setup/teardown the more benefit you get from HOF
        // 2. Avoiding duplication - setup/teardown code is only written once
        // 3. Separation of concerns - setup/teardown code is separated into the ConnectionHelper class

        public IEnumerable<LogMessage> GetLogs(DateTime since)
        {
            using var conn = new SqlConnection(ConnectionString);
            conn.Open();
            var messages = conn.Query<LogMessage>(SelectFromLogsSinceSql, new {since });
            return messages;
        }
        
        

        public int MyExecutor(LogMessage message) 
            => Connect(ConnectionString, conn => conn.MyExecute(5, 10));
        
        public IEnumerable<LogMessage> GetLogsFunctional(DateTime since) 
            => Connect(ConnectionString, conn => conn.Query<LogMessage>(SelectFromLogsSinceSql, new{since}));
    }
    
    

    public static partial class SqlMapper
    {
        public static int MyExecute(this IDbConnection cnn, int number1, int number2) 
            => number1+ number2;
    }
}