using LaYumba.Functional;

namespace LaYumba.Exercises.Chapter06;

using static F;

static class Solutions
{
   // 1 Implement Map for ISet<T> and IDictionary<K, T>. (Tip: start by writing down
   // the signature in arrow notation.)

   // Map : ISet<T> -> (T -> R) -> ISet<R>
   static ISet<R> Map<T, R>(this ISet<T> ts, Func<T, R> f)
   {
      var rs = new HashSet<R>();
      foreach (var t in ts)
         rs.Add(f(t));
      return rs;
   }
   
   
   
   
   
   
   
   
   

   // Map : IDictionary<K, T> -> (T -> R) -> IDictionary<K, R>
   static IDictionary<K, R> Map<K, T, R>
      (this IDictionary<K, T> dict, Func<T, R> f)
   {
      var rs = new Dictionary<K, R>();
      foreach (var pair in dict)
         rs[pair.Key] = f(pair.Value);
      return rs;
   }


   // 2 Implement Map for Option and IEnumerable in terms of Bind and Return.

   public static Option<R> Map<T, R>(this Option<T> opt, Func<T, R> f)
      => opt.Bind(t => Some(f(t)));

   public static IEnumerable<R> Map<T, R>(this IEnumerable<T> ts, Func<T, R> f)
      => ts.Bind(t => List(f(t)));


   // 3 Use Bind and an Option-returning Lookup function (such as the one we defined
   // in chapter 3) to implement GetWorkPermit, shown below. 

   static Option<Chap6WorkPermit> GetWorkPermit(Dictionary<string, Chap6Employee> employees, string employeeId)
      => employees.Lookup(employeeId).Bind(e => e.WorkPermit);


   // Then enrich the implementation so that `GetWorkPermit`
   // returns `None` if the work permit has expired.

   static Option<Chap6WorkPermit> GetValidWorkPermit(Dictionary<string, Chap6Employee> employees, string employeeId)
      => employees
         .Lookup(employeeId)
         .Bind(e => e.WorkPermit)
         .Where(HasExpired.Negate());

   static Func<Chap6WorkPermit, bool> HasExpired => permit 
      => permit.Expiry < DateTime.Now.Date;


   // 4 Use Bind to implement AverageYearsWorkedAtTheCompany, shown below (only
   // employees who have left should be included).

   static double AverageYearsWorkedAtTheCompany(List<Chap6Employee> employees)
      => employees
         .Bind(e => Map(e.LeftOn, leftOn => YearsBetween(e.JoinedOn, leftOn)))
         .Average();

   // a more elegant solution, which will become clear in Chapter 9
   static double AverageYearsWorkedAtTheCompany_LINQ(List<Chap6Employee> employees)
      => (from e in employees
            from leftOn in e.LeftOn
            select YearsBetween(e.JoinedOn, leftOn)
         ).Average();

   static double YearsBetween(DateTime start, DateTime end)
      => (end - start).Days / 365d;
}