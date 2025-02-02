using FunctionalCSharp.MyYumba;
using Unit = System.ValueTuple;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling;

public static class PrepareMeal
{
    public static YEither<ReasonWhy, Unit> WakeUpEarly()
    {
        Console.WriteLine("Today I Wake up at 6 O' Clock");
        return new YEither<ReasonWhy, Unit>();

    }
    
    public static YEither<ReasonWhy, Ingredients> ShopForIngredients()
    {
        return new ReasonWhy("The shop was close on Tuesday");
    }
    
    public static  YEither<ReasonWhy, Food> CookRecipe(Ingredients ingredients)
    {
        return new Food();
    }

    public static void EnjoyTogether(Food dish)
    {
        Console.WriteLine("Enjoying a lovely dish");
    }
    
    public static void ComplainAbout(ReasonWhy reason)
    {
        Console.WriteLine($"Complaining about {reason.Reason}");
    }
    
    public static void OrderPizza()
    {
        Console.WriteLine("Order Pizza now");
    }
    
    
    
}

public record ReasonWhy(string Reason);

public class Food
{
}

public class Ingredients
{
}