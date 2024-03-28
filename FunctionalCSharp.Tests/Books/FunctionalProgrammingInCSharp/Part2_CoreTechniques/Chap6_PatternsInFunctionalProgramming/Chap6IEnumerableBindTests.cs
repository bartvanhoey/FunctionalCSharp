using FunctionalCSharp.MyYumba;
using Shouldly;
using Pet = System.String;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public  class Chap6IEnumerableBindTests
{
    [Fact]
    public void Test_YBind_IEnumerable()
    {
        var neighbors = new Neighbor[]
        {
            new(Name: "John", Pets: new[] { "Fluffy", "Thor" }),
            new(Name: "Tim", Pets: new Pet[] { }),
            new(Name: "Carl", Pets: new[] { "Sybil" })
        };

        IEnumerable<Pet> GetPets(Neighbor n) => n.Pets;

        // MAP yields a nested IEnumerable => [["Fluffy", "Thor"],[],["Sybil"]]
        // var nestedPets = neighbors.YMap(n => n.Pets);
        var nestedPets = neighbors.YMap(GetPetsOfNeighbor);
        
        // BIND yields a Flat IEnumerable => [["Fluffy", "Thor", "Sybil"]]
        // var pets = neighbors.YBind(n => n.Pets);
        var pets = neighbors.YBind(GetPetsOfNeighbor);
        pets.ShouldBe(["Fluffy", "Thor", "Sybil"]);
    }

    private IEnumerable<Pet> GetPetsOfNeighbor(Neighbor n) => n.Pets;
}

public record Neighbor(string Name, IEnumerable<Pet> Pets);