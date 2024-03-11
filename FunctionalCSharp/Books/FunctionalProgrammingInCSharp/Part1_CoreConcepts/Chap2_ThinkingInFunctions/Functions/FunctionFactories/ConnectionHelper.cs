using System.Data;
using Microsoft.Data.SqlClient;
using static FunctionalCSharp.Extensions.YumbaFunctionalExtensions;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap2_ThinkingInFunctions.Functions.
    FunctionFactories
{
    public static class ConnectionHelper
    {
        public static T Connect<T>(string connectionString, Func<IDbConnection, T> func)
        {
            using var conn = new SqlConnection(connectionString);
            conn.Open();
            return func(conn);
        }
        
        public static T ConnectUsingFunctional<T>(string connString, Func<IDbConnection, T> func)
            => Using(new SqlConnection(connString), conn =>
            {
                conn.Open();
                return func(conn);
            });
    }
    
}