using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using static System.Data.CommandType;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_ThinkingInFunctions.Functions.FunctionFactories.ConnectionHelper;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_ThinkingInFunctions.Functions.FunctionFactories;

public class DbLogger
{
    private const string DbConnectionString = "connectionString";
    private const string SelectFromLogsSinceSql = "SELECT * FROM [Logs] WHERE [Timestamp] > @since";
        
    // Initial implementation
    public int Log(LogMessage message)
    {
        using var conn = new SqlConnection(DbConnectionString);
        conn.Open();
        var result = conn.Execute("sp_create_Log", message, commandType: StoredProcedure);
        return result;
    }

        
    // functional implementation
    public int LogFunctional1(LogMessage message) 
        => Connect(DbConnectionString, conn => conn.Execute("sp_create_log", message, commandType: StoredProcedure));
        
    // functional implementation
    public int LogFunctional2(LogMessage message) 
        => ConnectWithUsing(DbConnectionString, conn => conn.Execute("sp_create_log", message, commandType: StoredProcedure));
        
    // Benefits of using HOFs that takes a function as an argument
    // 1. Conciseness - the bigger setup/teardown the more benefit you get from HOF
    // 2. Avoiding duplication - setup/teardown code is only written once
    // 3. Separation of concerns - setup/teardown code is separated into the ConnectionHelper class

    public IEnumerable<LogMessage> GetLogs(DateTime since)
    {
        using var conn = new SqlConnection(DbConnectionString);
        conn.Open();
        var messages = conn.Query<LogMessage>(SelectFromLogsSinceSql, new {since });
        return messages;
    }
        
    // functional implementation
    public IEnumerable<LogMessage> GetLogsFunctional(DateTime since) 
        => ConnectWithUsing(DbConnectionString, conn => conn.Query<LogMessage>(SelectFromLogsSinceSql, new{since}));

        

    public int MyExecutor(LogMessage message) 
        => ConnectWithUsing(DbConnectionString, conn => conn.MyExecute(5, 10));
        
        
}
    
    

public static partial class SqlMapper
{
    public static int MyExecute(this IDbConnection cnn, int number1, int number2) 
        => number1+ number2;
}