# Functional Programming

Using a functional programming language like Erlang will cut your code size by 70% compared to C code. Tony Wallace

On average, 40% of a code base is clutter!

Code on average is read 15-20 times more often than it's written.
    => deleting unnecessary code now, will give you 15-20 extra time in the future

## What is Functional Programming

Functional programming (FP) is a powerful paradigm that can help you make
your code more concise, maintainable, expressive, robust, testable, and
concurrency-friendly.

Functional Programming is like a philosophy of transparency. In doing so, we
create code that other developers can trust, understand, and build upon.

## Why Functional Programming

Biggest problem in software development is complexity. Complexity of a code base affects Development Speed, Number of Bugs, Agility,
Maintainability, etc. The more complex the software, the more difficult it is to maintain!

A developer/developer team can only deal with a certain amount of complexity!
If the complexity exceeds this limit, it will be difficult/impossible to maintain the software/to develop new features.
Complexity slows downs the development process or even introduces new bugs or can even lead to a project failure.

Applying **Functional Programming Principles** helps to reduce Code Complexity and results in more Predictable, Reliable and
Maintainable and Testable code. 



If the only tool you have is a hammer, every problem looks like a nail. - Abraham Maslow

The more angles from which you can approach a problem, the more likely you are to find an optimal
solution. - Alan Perlis


## C# Functional

### LINQ

### Importing Static Members with the Using static Directive

use static enables unqualified access to static members without further qualification (without specifying the class name)

```csharp
    using static System.Math;

    public double Circumference => PI * 2 * Radius;
    
    // instead of 
    public double Circumference => Math.PI * 2 * Radius;
```

You can also make use of **global using static** to make functions available throughout your project.


### More Concise Functions with Expression-Bodied Members 

In FP, you write lots of simple functions, many of them one-liners, and then
compose them into more complex workflows.

```csharp
    public double Circumference => PI * 2 * Radius;
```

The **expression-bodied syntax** was introduced in C# 6 for methods and property
getters. It was generalized in C# 7 to also apply to constructors, destructors, getters,
and setters.


### Getter-only auto-properties can only be set in the constructor

### Local functions

### Language Support for tuples

In FP, you often write small functions, where you end up with a data type whose only
purpose is to capture the information returned by that function, and that’s expected
as input by another function. 

It’s impractical to define dedicated types for such structures. => Tuples

```csharp
    public static (string BaseCurrency, string QuoteCurrency) AsPair(this string currencyPair) 
        => currencyPair.SplitAt(3);

```

The tuple syntax allows you to elegantly write and consume methods that need to return more than one value. 
There’s no good reason to define a dedicated type to hold together those values.

### Taming Side effects

### Favoring Expressions over Statements

```csharp
// Statement
string  posOrNeg;
if(value >0)
{
    posOrNeg = "positive";
}
else
{
    posOrNeg = "negative"
}
var message = $"{value} is {posOrNeg}"
```

### Emphasis expressions

### Treating functions as data

## Honest vs Dishonest Functions

A Dishonest function doesn't abide by its signature: int -> Risk (should return Risk, but can throw an ArgumentException)

Make your functions honest. An honest function always does what its signature says, 
and given an input of the expected type, it yields an output of the expected type—no Exceptions, no nulls.

```csharp
  public static Risk CalculateRiskProfile(int age)
  {
      if (age is < 0 or >= 120)
         throw new ArgumentException($"{age} is not a valid age");
          
         return age < 60 ? Risk.Low : Risk.High;
   }
         
```

An honest function always does what its signature says, and given an input of the expected type. 
A function is honest when
  * returns an output of the expected type
  * does not throw Exceptions
  * never returns null

Signature: Age -> Risk

Attention: An Impure Function, has for example an I/O operation, can still be an Honest Function!


```csharp
    public static Risk CalculateRiskProfile(Age age) 
        => age < 60 ? Risk.Low : Risk.Medium;
```
ATTENTION: an honest function can still be impure. 
An honest function abides its signature, but still can perform I/O operations

## Difference between OO Programming and FP Programming

OO makes code understandable by encapsulating moving parts.
FP makes code understandable by minimizing moving parts. - Michael Feathers

In OO, data and behavior live in the same object, and methods in the object can typically modify the object’s state. 
In FP data is captured with “dumb” data objects while behavior is encoded in functions, data and behavior are seperated

## Imperative vs Functional (Declarative) programming

Imperative code relies on statements (if, for, for each ...), Functional code relies on expressions

## Software rot

Software rot, also known as bit rot, code rot, software erosion, software decay, or software entropy is either a slow
deterioration of software quality over time or its diminishing responsiveness that will eventually lead to software
becoming faulty, unusable, or in need of upgrade. This is not a physical phenomenon: the software does not actually
decay, but rather suffers from a lack of being responsive and updated with respect to the changing environment in which
it resides. (Wikipedia)

## Lambda operator => "goes to" operator

(l, r) => l + r; // l and r go to an expression

## Immutability / Immutable types

Inability to change data after it has been created. Once created, an immutable object cannot be modified later on.

## State

Data that changes over time. An immutable class doesn't have any state.

## (Taming) Side effects  => Functional Purity

## Purity/Pure functions // mathematical functions

A function is pure if it has no side effects and always returns the same output/result for the same input (arguments).
Increases the readability and predictability of a program.

IN FP, we prefer functions whose behavior relies on their input arguments. 
These pure functions are implemented as static methods in C#!  

As you code more functionally, more of your functions will be pure, so more of your code will be in static classes.




## Impure functions

Are functions that have side effects 
* Mutates global state
* Mutates its input arguments
* throws exception
* performs any I/O operations

A function should never mutate its input arguments. (you can use immutable objects)

Impure functions have implicit inputs other than
its arguments or implicit outputs other than its return value or both

## Command-Query Separation Principle

* A **command** is a method that **performs an action but does not return a value**. Has Side effects.
* A **query** is a method that **returns a value but does not perform an action**. Has no Side effects.

## Mapping

Given a sequence and a function, mapping yields a new sequence
with the elements obtained by applying the given function to each element in
the given sequence (in LINQ, this is done with the Select method).

Enumerable.Range(1, 3).Select(i => i * 3) // => [3, 6, 9]

## Fail Fast Principle
- Shortening the feedback loop
- Confidence in the working of the code
- Protects the persistence state

## Filtering

Given a sequence and a predicate, filtering yields a new sequence
consisting of the elements from the given sequence that pass the predicate
(in LINQ, Where).
Enumerable.Range(1, 10).Where(i => i % 3 == 0) // => [3, 6, 9]

## Sorting

Given a sequence and a key-selector function, sorting yields a new
sequence ordered according to the key (in LINQ, OrderBy and OrderByDescending).


Enumerable.Range(1, 5).OrderBy(i => -i) // => [5, 4, 3, 2, 1]

## Pipelining vs Nested Method Calls // Railway-oriented approach

Pipelining allows data to flow between functions




## Method chaining vs Function Composition

### Function Composition

Function Composition means combining 2 or more functions into a new function.

In C# functions appear in the reverse order in which they’re executed.
AbbreviateName (most right) gets executed first, AppendDomain after ... not good for readability.

````csharp
// Function Composition
var joe = new Person("Joe", "Bloggs"); 
string EmailFor(Person p) => AppendDomain(AbbreviateName(p));
// => jobl@manning.com
````

### Method Chaining
**Method Chaining**, chaining several method with **the . operator**, provides a more readable way of function composition in C#
The **Extension Methods** appear in the order in which they will be executed and significantly improves readability.

````csharp
// Method Chaining
var joe = new Person("Joe", "Bloggs");
var email = joe.AbbreviateName().AppendDomain();
// => jobl@manning.com

````

````csharp
    // LINQ, is  a good example of method chaining
    Enumerable.Range(1, 100).Where(i => i % 2 == 0).Reverse();
````

### Data Flows

Start to look at your program in terms of data flow (workflow).
Your program is a pipeline of functions and data flows through one function into the next.

In the snippet below, the input data flows through four transformative steps to return the output

````csharp
var average =List<Person> => OrderBy() => Take() => Select() => Average(): 
````

Properties that make functions easier to compose:

* Pure: no side effects
* Chainable: (this in extension methods)
* General: the more specific a method, the less likely it is to be reusable
* Shape-preserving: the output type should be the same as the input type
* functions are more composable actions. 
 
An action has no output, it is a dead end and can only come at the end of pipeline. 
A function has an output, it is a pipeline.

### Extension methods

Extension methods in C# are a way to add new methods to existing types without modifying the original type,
or creating a new derived type. 
They allow you to "extend" existing types with new functionality in a static, reusable, and organized way.

## Programming workflows

A workflow is a meaningful sequence of operations leading to a desired result.

Each **operation in the workflow** can be performed by a **function**, 
and these functions can be composed into **Function Pipelines** that perform the workflow.

 


## Expressions vs Statements (Expression Composition)

Functional code prefers expressions to statements.
Relying on expressions leads to more declarative and more readable code.

Expressions return a value. Statements do not return a value.

Statement

´´´csharp
string posOrNeg;
if (value > 0)
{
    posOrNeg = "positive"
}
else
{
    posOrNeg = "negative"
}

var message = §"{value} is {posOrNeg}"
´´´

Expression

´´´csharp
    // var posOrNeg = (value > 0) ? "positive" : "negative"
    // Expression Composition
    var message = $"{value} is {(value > 0 ? "Positive" :"negative")}"

´´´

## Stateful computations

## Primitive Obsession

Primitive obsession stands for the use of primitive types instead for domain modeling.
Primitives types are often used too liberally. If you need to constrain the inputs of a function,
it's usually better to use a custom type. (int age vs Age age)

## Railway-oriented programming

## Partial Application

You give a function some arguments, and it returns a new function that takes the remaining arguments.
Partial Application allows you to fix a function's arguments.This lets you derive new function with specific behavior
from other, more general functions.

## Currying

Named after Haskell Curry, curry is a technique of transforming a function that takes multiple arguments
into a function that takes a single argument and returns another function that takes the next argument, and so on.

Currying transforms a function that accepts multiple arguments “all at once” into a series of function calls,
each of which involves only one argument at a time.

´´´csharp
// n-ary function wth signature
(T1, T2, ..., Tn) -> R

    // Curried function
    T1 -> T2 -> ... -> Tn -> R

´´´

## Higher-order extensions methods

## Referential Transparency

An expression is said to be referential transparent if it can be replaced with its corresponding value
without changing the program's behavior, or Replace a function with its return value.

## Referentially Opaque

## Functions are first-class citizens

## Higher-order functions (HOFs)

HOFs are functions that take other functions as inputs, or return other functions as output, or both

## Parallelization

Different threads carry out tasks in parallel

## Memoization

Cache results to avoid repeated function evaluations

## Lazy evaluation

Only evaluate values as needed

## Lambda Expressions

Lambdas are used to declare a function inline.

var list = Enumerable.Range(1, 10).Select(i => i * 3).ToList();
list // => [3, 6, 9, 12, 15, 18, 21, 24, 27, 30]

list.Sort((l, r) => l.ToString().CompareTo(r.ToString()));
list // => [12, 15, 18, 21, 24, 27, 3, 30, 6, 9]

## Closure

A closure is the combination of the lambda expression itself along with the context in which that lambda is
declared (all the variables available in the scope where the lambda appears).

Closures are inline anonymous methods that have the ability to use Parent
method variables and other anonymous methods which are defined in the parent's scope.

greetWith : Greeting -> (Name -> PersonalizedGreeting) or Greeting -> Name -> PersonalizedGreeting

Func<Greeting, Func<Name, PersonalizedGreeting>> greetWith = gr => name => $"{gr}, {name}";

The function, greetWith, takes a single argument, the general greeting, and returns a new function of type Name ->
Greeting.

Notice that when the function is called with its first argument, gr, this is captured in a closure
and is therefore “remembered” until the returned function is called with the second argument, name.

var greetFormally = greetWith("Good evening");

names.Map(greetFormally).ForEach(WriteLine);
// prints: Good evening, Tristan

## Function Arity

Refers to the number of arguments that a function accepts:

* A nullary function takes no arguments.
* A unary function takes one argument.
* A binary function takes two arguments.
* A ternary function takes three arguments.

## Elvis operator // null coalescing operator

## Yield keyword

## Declarative (functional) programming vs imperative programming

The difference between the functional and imperative style is that
imperative code relies on statements; functional code relies on expressions 

By preferring expressions to statements, your code becomes more declarative, and hence more readable.

=> Some(transfer).Map(Normalize).Where(validator.IsValid).ForEach(Book);

This Functional Code reads much like a bullet-point definition of a workflow. 
The code is closer to the spoken language and, easier to understand and to maintain. 

## Arrow Notation

f: int -> string = Func<int, string>

|Function signature                 | C# type|Example           | Example                                       |
|int -> string                      | Func<int, string>         | (int i) => i.ToString()                       |
|() -> string                       | Func<string>              | () => "Hello"                                 |
|int -> ()                          | Action<int>               | (int i) => Console.WriteLine($"gimme "{i}")   |
|()  -> ()                          | Action                    | () => Console.WriteLine("Hello world")        |
|(int,int) -> int                   | Func<int, int, int>       | (int i, int j) => i + j                       |

(IEnumerable<T>, (T -> bool)) -> IEnumerable<T> // Could be Enumerable.Where
(IEnumerable<A>, IEnumerable<B>, ((A, B) -> C)) -> IEnumerable<C> //Could be Enumerable.Zip

## Monads and Functors

### Functors (must have a Map function defined)

Functors are types for which a suitable **Map function** is defined.
Map should apply a function to the container's inner value and do nothing else (no side effects).

Map: (C<T>, (T -> R)) -> C(R)
Map: (IEnumerable<T>, (T -> R)) -> IEnumerable<R>)
Map: (Option<T>, (T -> R)) -> Option<R>)

When using functors and monads, try to use function that stay within the abstraction, like Map and Bind.
Use the downward-crossing Match function as little or as late as possible

In FP, a type for which such a Map function is defined is called a functor.2 IEnumerable
and Option are functors, as you’ve just seen, and you’ll meet many more in the book.
For practical purposes, we can say that anything that has a reasonable implementation
of Map is a functor. But what’s a reasonable implementation? Essentially, 3


### Monads (must have Bind and Return functions defined)
A **Monad** is a type C<T> for which  a **Bind function** and a **Return function** is defined.

**Return** is a (upward-crossing) function that lifts/wraps a normal value T into a **monadic value C<T>**

* Return: T -> C<T>

    In LaYumba, the Return function for **Option** is the **Some** function
    In LaYumba, the Return function for **IEnumerable** is the **List** function

**Bind** takes a **container C<T>** and a **Container-returning-function f with signature (T -> C<R>)** and applies the function to the inner value,
and flattens the result (returns a C<R>) to avoid producing a nested container

* Bind: (C<T>, (T -> C<R>)) -> C<R>

Certain rules must be implemented for the type to be considered as a proper monad (monad laws)

**ATTENTION: Every monad is also a functor!**

### Monad Laws

### Relation between Monads and Functors

### Natural Transformation 

Functions that map between functors, such as AsEnumerable, are called **Natural Transformations**
If the Option is Some, its results an IEnumerable with one item. If None, an empty IEnumerable. 

```csharp
public struct Option<T>
{
    public IEnumerable<T> AsEnumerable()
    {
        if (isSome) yield return value!;
    }
}

// example
optInt.AsEnumerable() returns an IEnumerable of integers
```

## Higher-kinded types

## Recursion

## Pattern matching

## Dynamic Programming

Dynamic Programming (a.k.a. dynamic optimization) is a method for solving a complex problem
by breaking it down into a collection of simpler sub problems, solving each of those just once,
and storing their solutions.

## Clean Code Function Rules

* Keep functions small
* don't repeat yourself
* do one thing
* avoid side effects
* function should accept no more than 3 parameters
* try to avoid indentation
* go for the positive if instead of the negative

## Core Functions in Functional Programming

### Fold/Reduce (=Aggregate in Linq)

Reducing a list of values into a single value. Reduce/Fold/Aggregate Takes a list of n things and returns exactly one
thing.

(IEnumerable<T>, Acc, ((Acc, T) -> Acc)) -> Acc

var oldestAge = people.Fold(0, (age, person) => person.Age > age ? person.Age : age)

### Map (=Select in Linq) : Takes a regular function

Map takes an container C<T> (elevated value) and a regular function (T -> R) and returns a container C<R> 

Map should apply a function to the container’s inner value(s) and should do nothing else. 
Map should have no side effects.

A type for which a Map function is defined is called a Functor

or

Map takes a structure and a function and applies the function to every element in the structure, returning a new
structure with the results.
Map: (C<T>, (T -> R)) -> C(R)
Map: (IEnumerable<T>, (T -> R)) -> IEnumerable<R>
Map: (Option<T>, (T -> R)) -> Option<R>

**Option.Map : (Option<T>, (T -> R)) -> Option<T>)**

When you call Map on an Option<T>, a Func<T, R> (a method with parameter type T, with return value R) is executed 
on the internal value (type T) of the Option and you get a new option of type R as a result.

(Option<Person>, (Person -> string)) -> Option<string>)

Func<Person, string> generateEmailAddress = person => $"{person.FirstName}{person.LastName}@mycompany.com";

Option<Person> optionPerson = F.Some(new Person("Joe", "Smith"));

Option<string> optionEmailAddress = optionPerson.Map(generateEmailAddress);

### Filter (=Where in Linq)

Where, filters the inner value(s) of a structure according to a given predicate

### Bind (=SelectMany in Linq) : Takes an upward-crossing function

Bind takes a container C<T> (elevated value) and a container-returning-function (upward-crossing function) (T -> C<R>) 
and applies the function to the inner value, and flattens the result (returns a C<R>) to avoid producing a nested container

Bind: (C<T>, (T -> C<R>)) -> C<R>

**Option.Bind : (Option<T>, (T -> Option<R>)) -> Option<R>**
vs Option.Map : (Option<T>, (T -> R)) -> Option<R>)

Bind takes and **Option** and an **Option-returning function** and applies the function to the inner value if the Option is Some,
otherwise returns None and flattens the result to avoid producing a nested Option.

### Reduce = is a Fold function that has no initial state, takes its initial state from the first item in the sequence

### Tee Command

The Tee command in UNIX is a command line utility for copying standard input to standard output. 
It supports writing whatever it is given from standard input to standard output and optional writing to one or more files.

### ForEach

ForEach is used for its side-effect. Foreach is similar to Map, but it takes an Action rather than a Function, 
which it performs for each of the container's inner values.

### Return

Return is a function that takes a normal value T and lifts it into an elevated value C<T> .

In LaYumba, the Return function for **Option** is the **Some** function
In LaYumba, the Return function for **IEnumerable** is the **List** function


## Predicate functions (aka boolean functions)

A predicate function is a function that returns True or False



## Guarding against NullReferenceExceptions

Never write a function that explicitly returns null, and always check that the inputs aren't null before using
them. [Fody NullGuard]

## Smart constructors

Is a function that takes a primitive type as input and returns Some or None to indicate the successful creation of a
custom type. By providing a smart constructor, you can make the constructor private, and you can ensure that the custom type is always
created with valid data.

## Option type

Option<T> = None | Some(T)

When coding functionally, you never use null—ever. Instead, FP uses the Option type to represent optionality.

An Option can be in one of two states:

* None: the absence of a value. The Option is None.
* Some(T): a simple container wrapping a non-null value. The Option is Some.

An important thing to realize is that Option abstracts away whether a value is present or not. 
If you Map a function onto an Option, you don't care whether the value is there or not.

#### Separate pure logic from side effects

You should aim to separate pure logic from side effects =>  use Map for logic and ForEach for side effects

Option<string> optJohn = Some("John");
optJohn.ForEach(name => WriteLine($"Hello {name}"))

becomes (logic separated from side effects)

optJohn.Map(name => $"Hello {name}".ForEach(WriteLine))

## Validation vs Exception

* Validation indicates that some business rule has been violated.
* Exception denotes an unexpected technical error

## Error Handling in Function Programming

Functional Programming strives to minimize side effects, throwing exceptions is generally avoided.

If an operation fails, it includes an indication of Success or Failure, as well as its result (successful) or some error data (unsuccessful)
Errors  in FP are just payload.

### Either type

to represent a value that can have 2 possible outcomes: Success or Failure
Left: something went wrong
Right: all right

Either is rather abstract, so it's often more useful tos use a more specific type, such as Exceptional or Validation

## Try type

## Partial Application

Partial application is the process of fixing a number of arguments to a function, producing another function of smaller
arity.

### Zip

Zip in FP is the operation of paring up the elements of two parallel lists into a single list.

## Clean Code

Keep functions small
Don't repeat yourself
Do one thing
Avoid side effects
Functions should not accept more than 3 parameters

## Defensive Null-Checking

To prevent the NullReferenceException occurring, developers add null checks. 
These null checks are definitely needed, but they create a lot of noise in the codebase.

## Function Types in Functional Programming

### downward-crossing functions

Functions mapping elevated values to a regular values. 
* Average, Sum and count for IEnumerable.
* Match for Option

### upward-crossing functions (World-crossing functions)

Functions mapping regular values to a elevated values. Some("apple"), Int.Parse("5"),   
World-crossing functions are functions that go 
    from the world of **normal values T** to the world of **elevated values (C<T>)**

### Functions mapping Elevated values

These functions remain within the abstraction (elevated world), like Map, Bind, Where, OrderBy, ...


## C# New Language Features

### Range Operator

````csharp
    public static class StringSplitter
    {
        public static (string baseCurrency, string quoteCurrency) SplitAt(this string @this, int at) => (@this[..at], @this[at..]);
    }
````

### Collection Initializers

### Records

Records—Boilerplate-free immutable types with built-in support for creating modified versions

```csharp
   record Product(string Name, decimal Price, bool IsFood);
```

Notice how with a single line, you can define the Product type! The compiler generates
a constructor, property getters, and several convenience methods such as Equals,
GetHashCode, and ToString for you.

NOTE Records in C# 9 are reference types, but C# 10 allows you to use
record syntax to define value types by simply writing record struct rather
than just record. 

Somewhat surprisingly, record structs are mutable, and you
have to declare your struct as readonly record struct if you want it to be
immutable.

### Pattern matching

Pattern matching—Lets you use the switch keyword to match not only on specific
values but also on the shape of the data, most importantly its type

### Switch expression instead of the Switch statement

```csharp
  // Switch Expression with Positional Pattern
  public static decimal GetSalesTax(Order order, Address address) => address switch
  {
    // Address("de", _, _, _) => GetGermanSalesTax(order),
    //  Address(var country, _, _, _) => GetSalesTax(RateByCountry(country), order)
    ("de", _, _, _) _ => GetGermanSalesTax(order),                  
    (var country, _, _, _) _ => GetSalesTax(RateByCountry(country), order)
   };
  
  // Switch Expression with Property Pattern
  public static decimal GetSalesTax(Order order, Address address) => address switch
  {
    { Country:  "de" } => GetGermanSalesTax(order),                  
    { Country:  var country }  => GetSalesTax(RateByCountry(country), order)
   };
  
  public record Address(string Country, string City, string Street, string PostalCode);
  
```

