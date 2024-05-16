using FunctionalCSharp.MyYumba;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.PrepareMeal;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling;

public class PrepareMealTests
{

    [Fact]
    public void Test_PrepareMeal()
    {
        var result = WakeUpEarly().YBind(_ => ShopForIngredients()).YBind(CookRecipe).YMatch(
            right: EnjoyTogether,
            left: reason =>
            {
                ComplainAbout(reason);
                OrderPizza();
            });

        

    }
    
}