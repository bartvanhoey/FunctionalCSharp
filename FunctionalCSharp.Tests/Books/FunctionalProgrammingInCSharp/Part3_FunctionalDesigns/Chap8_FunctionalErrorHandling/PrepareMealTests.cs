namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling;

public class PrepareMealTests
{

    [Fact]
    public void Test_PrepareMeal()
    {
        // throws ArgumentNullException -> Value cannot be null. (Parameter 'left')
        
        // var result = WakeUpEarly().YBind(_ => ShopForIngredients()).YBind(CookRecipe).YMatch(
        //     right: EnjoyTogether,
        //     left: reason =>
        //     {
        //         ComplainAbout(reason);
        //         OrderPizza();
        //     });

        

    }
    
}