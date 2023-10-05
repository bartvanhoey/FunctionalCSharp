// workaround to enable C# 9 syntax

using static LaYumba.Exercises.Chapter03.BmiExcercise;
using static LaYumba.Exercises.Chapter03.BmiSolution;

namespace System.Runtime.CompilerServices { public class IsExternalInit { } }

namespace Exercises
{
   public class Program
   {
      public static void Main(string[] args)
      {
         // run the program you've written, for example:
         //StartBmiProgramSolution();
         StartBmiProgramExcercise();

         Console.ReadLine();

      }
   }
}



