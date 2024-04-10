using FunctionalCSharp.MyYumba;
using LaYumba.Functional;
using static LaYumba.Functional.F;

namespace LaYumba.Exercises.Chapter06;

static class Exercises
{
   // 1 Implement Map for ISet<T> and IDictionary<K, T>. (Tip: start by writing down
   // the signature in arrow notation.)
   
   // See YiSetExtensions and YiDictionaryExtensions
   
   // 2 Implement Map for Option and IEnumerable in terms of Bind and Return.
   
   // public static Option<R> Map<T,R>(this Option<T> opt, Func<T,R> func) 
   //    => opt.Bind(t => Some(func(t)));
   //
   // public static IEnumerable<R> Map<T, R>(this IEnumerable<T> items, Func<T, R> func) 
   //    => items.Bind(t => List(func(t)));
   //
   //
   
    // 3 Use Bind and an Option-returning Lookup function (such as the one we defined
    // in chapter 3) to implement GetWorkPermit, shown below. 
   
   // Then enrich the implementation so that `GetWorkPermit`
   // returns `None` if the work permit has expired.
   
   static YOption<Chap6ExWorkPermit> GetWorkPermit(Dictionary<string, Chap6ExEmployee> employees, string employeeId) 
      => employees.YLookup(employeeId).YBind(e => e.WorkPermit);
   
   static YOption<Chap6ExWorkPermit> GetValidWorkPermit(Dictionary<string, Chap6ExEmployee> employees, string employeeId) 
      => employees.YLookup(employeeId)
         .YBind(e => e.WorkPermit)
         .YWhere(HasWorkPermitExpired.YNegate());

   private static Func<Chap6ExWorkPermit, bool> HasWorkPermitExpired => permit => permit.Expiry < DateTime.Now.Date;

   // // 4 Use Bind to implement AverageYearsWorkedAtTheCompany, shown below (only
   // // employees who have left should be included).
   //
   // static double AverageYearsWorkedAtTheCompany(List<Employee> employees)
   // {
   //    // your implementation here...
   //    throw new NotImplementedException();
   // }
}

public record Chap6ExEmployee
(
   string Id,
   YOption<Chap6ExWorkPermit> WorkPermit,
   DateTime JoinedOn,
   Option<DateTime> LeftOn
);

public record Chap6Employee
(
   string Id,
   Option<Chap6WorkPermit> WorkPermit,
   DateTime JoinedOn,
   Option<DateTime> LeftOn
);

public record Chap6ExWorkPermit
(
   string Number,
   DateTime Expiry
);

public record Chap6WorkPermit
(
   string Number,
   DateTime Expiry
);