# Functional Programming in C#


## Expression bodied properties

```csharp   
public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => $"{FirstName} {LastName}";
}
```

## Expression bodied methods

```csharp

public class Person
{
    public string GetFullName() => $"{FirstName} {LastName}";
}
```

## Expression bodied constructors

```csharp
public class Person
{
    public Person(string firstName, string lastName) => (FirstName, LastName) = (firstName, lastName);
}
```

## Import static members

```csharp
using static System.Math;

public class Circle
{
    public double Radius { get; set; }
    public double Area => PI * Pow(Radius, 2);
}
```
