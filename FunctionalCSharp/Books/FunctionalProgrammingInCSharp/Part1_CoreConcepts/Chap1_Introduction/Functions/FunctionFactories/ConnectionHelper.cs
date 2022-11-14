using System.Data;
using Microsoft.Data.SqlClient;
using static FunctionalCSharp.Extensions.YumbaFunctionalExtensions;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction.Functions.FunctionFactories
{
    public static class ConnectionHelper
    {
      public static T Connect<T>(string connectionString, Func<IDbConnection, T> func)
      {
        using var iDbConn = new SqlConnection(connectionString);
        iDbConn.Open();
        return func(iDbConn);
      }
      
      public static T ConnectFp<T>(string connString, Func<IDbConnection, T> func) 
          => Using(new SqlConnection(connString), conn => 
          {
              conn.Open();
              return func(conn);
          });
      
    }
    
    
}