using System.Data;
using Microsoft.Data.SqlClient;
using static FunctionalCSharp.FunctionalProgrammingInCSharp.LaYumba.Functional.F;

namespace FunctionalCSharp.FunctionalProgrammingInCSharp.Chapter1Introduction.Functions.FunctionFactories
{
    public static class ConnectionHelper
    {
        public static TR Connect<TR>(string connString, Func<IDbConnection, TR> func) 
            => Using(new SqlConnection(connString), conn => 
            {
                conn.Open();
                return func(conn);
            });
    }
}