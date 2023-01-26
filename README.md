# Functional Programming

Using a functional programming language like Erlang will cut your code size by 70% compared to C code. Tony Wallace

On average, 40% of a code base is clutter!

Code on average is read 15-20 times more often than it's written. 
    => deleting unnecessary code now, will give you 15-20 extra time in the future)

## What is Functional Programming

... a paradigm which concentrates on computing results
rather than on performing actions

## Why Functional Programming

Biggest problem in software development is complexity. Complexity affects Development Speed, Number of Bugs, Agility, Maintainability, etc.
The more complex the software, the more difficult it is to maintain. 

A developer team can only deal with a certain amount of complexity! 
If the complexity exceeds this limit, it will be difficult/impossible to maintain the software/to develop new features. Slows downs the development process or even introduces new bugs.

Functional programming helps to reduce code complexity.

## Benefits of Functional Programming

FP is a powerful paradigm that can help you write code that is more concise, expressive, robust, more reliable, more maintainable, more testable and concurrency-friendly.

If the only tool you have is a hammer, every problem looks like a nail. - Abraham Maslow
Conversely, the more angles from which you can approach a problem, the more likely you are to find an optimal solution. - Alan Perlis

FP can be seen as a collection of techniques that are based on 2 fundamental principles:
* Functions are first-class citizens
* In-place updates should be avoided

### Taming Side effects
### Emphasis expressions
### Treating functions as data
 
Results in code that is more Predictable, Reliable and Maintainable and easier to test

## Difference between OO Programming and FP Programming

OO makes code understandable by encapsulating moving parts. 
FP makes code understandable by minimizing moving parts. - Michael Feathers

## Imperative vs Functional (Declarative) programming 

## Software rot
Software rot, also known as bit rot, code rot, software erosion, software decay, or software entropy is either a slow deterioration of software quality over time or its diminishing responsiveness that will eventually lead to software becoming faulty, unusable, or in need of upgrade. This is not a physical phenomenon: the software does not actually decay, but rather suffers from a lack of being responsive and updated with respect to the changing environment in which it resides. (Wikipedia)

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

Side effects : Mutates global state/Mutates its input arguments/throws exception/performs any I/O operations

## Command-Query Separation
* A command is a method that performs an action but does not return a value. Has Side effects.
* A query is a method that returns a value but does not perform an action. Has no Side effects.

## Mapping
Given a sequence and a function, mapping yields a new sequence
with the elements obtained by applying the given function to each element in
the given sequence (in LINQ, this is done with the Select method).

Enumerable.Range(1, 3).Select(i => i * 3) // => [3, 6, 9]

## Filtering 
Given a sequence and a predicate, filtering yields a new sequence
consisting of the elements from the given sequence that pass the predicate
(in LINQ, Where).

Enumerable.Range(1, 10).Where(i => i % 3 == 0) // => [3, 6, 9]

## Sorting
Given a sequence and a key-selector function, sorting yields a new
sequence ordered according to the key (in LINQ, OrderBy and OrderByDescending).

Enumerable.Range(1, 5).OrderBy(i => -i) // => [5, 4, 3, 2, 1]



## Pipelining // Railway-oriented approach
Pipelining allows data to flow between functions

## Method chaining
Method chaining is the OO version of pipelining

## Extension methods

## Expressions vs Statements (Expression Composition)
Expressions return a value. Statements do not return a value.

Statement

´´´csharp
    string posOrNeg;
    if (value > 0)
        posOrNeg = "positive"
    else
        posOrNeg = "negative"

    var message = §"{value} is {posOrNeg}"

´´´

Expression

´´´csharp
    // var posOrNeg = (value > 0) ? "positive" : "negative"

    // Expression Composition
    var message = $"{value} is {(value > 0 ? "Positivie" :"negative")}"
´´´

## Stateful computations

## Primitive Obsession
Primitive obsession stands for the use of primitive types instead for domain modeling.
Primitives are often use too liberally. If you need to constrain the inputs of a function, 
it's usually better to use a custom type. (int age vs Age age)

## Railway-oriented programming

## Currying

## Higher-order extensions methods

## Referential Transparency
An expression is said to be referential transparent if it can be replaced with its corresponding value 
without changing the program's behavior.

## Referentially Opaque

## Functions are first-class citizens

## Higher-order functions (HOFs)
HOFs are functions that take other functions as inputs, 
or return other functions as output, or both

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

## Function composition

Combining 2 or more functions into a new function. The output from one function is used as input for another function. 
Start to look at your program in terms of data flow. Your program is a pipeline of functions.

## Closure

Closures are inline anonymous methods that have the ability to use Parent 
method variables and other anonymous methods which are defined in the parent's scope.

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

## Arrow Notation

f: int -> string  = Func<int, string>

|Function signature | C# type|Example           | Example                                       |
|int -> string       | Func<int, string>         | (int i) => i.ToString()                       |
|() -> string        | Func<string>              | () => "Hello"                                 | 
|int -> ()           | Action<int>               | (int i) => Console.WriteLine($"gimme "{i}")   |
|()  -> ()           | Action                    | () => Console.WriteLine("Hello world")        |
|(int,int) -> int    | Func<int, int, int>       | (int i, int j) => i + j                       |

IEnumerable<T>, (T -> bool)) -> IEnumerable<T> // Could be Enumerable.Where
(IEnumerable<A>, IEnumerable<B>, ((A, B) -> C)) -> IEnumerable<C> //Could be Enumerable.Zip


## Partial Function Application

## Monad

It’s a specific way of chaining operations together. In essence, you’re writing execution steps and linking them together with the “Bind function”. (In Haskell, it’s named >>=.) 
You can write the calls to the bind operator yourself, or you can use syntax sugar which makes the compiler insert those function calls for you.

## Monads 

Monads are types for which a **Bind function** is defined. In addition to the Bind function, 
monads must also have a **Return function** that lifts a normal value T into a monadic value C<T>

A Monad is a type C<T> for which the following functions are defined:
* Return: T -> C<T>
* Bind: (C<T>, (T -> C<R>)) -> C<R>

Certain rules must be implemented for the type to be considered as a proper monad (monad laws)

## Functors

Functors are types for which a suitable **Map function** is defined. 
Map should apply a function to the functor's inner value and do nothing else.

## Recursion

## Pattern matching

## Dynamic Programming
Dynamic Programming (a.k.a dynamic optimization) is a method for solving a complex problem
by breaking it down into a collection of simpler sub problems, solving each of those just once,
and storing their solutions. 

## Clean Code Function Rules ()

* Keep functions small
* don't repeat yourself
* do one thing
* avoid side effects
* function should accept no more than 3 parameters

## Core Methods in Functional Programming

### Fold (=Aggregate in Linq) 
var oldestAge = people.Fold(0, (age, person) => person.Age > age ? person.Age : age)

### Map (=Select in Linq)  

Map should apply function that takes a container C<T> and a function f of type (T -> R),
and returns a container C<R> wrapping the value(s) resulting from applying f to the container's inner value(s).
Map should apply a function to the container’s inner value(s) and should do nothing else. Map should have no side effects.

or

Map takes a structure and a function and applies the function to every element in the structure, returning a new structure with the results.

#### Signature  

Map: (C<T>, (T -> R)) -> C(R)

(IEnummrable<T>, (T -> R)) -> IEnumerable<R>)
(Option<T>, (T -> R)) -> Option<R>)

### Filter (=Where in Linq) 

### Bind (=SelectMany in Linq) 

Bind: (C<T>, (T -> C<R>)) -> C<R>

Bind is a function that takes a container C<T> and a function f with signature (T -> R) and returns a container C<R>


### Reduce = is a Fold function that has no initial state, takes its initial state from the first item in the sequence

### Tee

### ForEach



## Predicate functions (aka boolean functions)
A predicate function is a function that returns True or False

## General Guidelines for Pure Functions

* Make pure functions static
* Avoid mutable static fields
* avoid direct calls to static methods that perfom I/O

As you code more functionally, more of your functions will be pure, so more of your code will be in static classes. 

## Guarding againts NullReferenceExceptions
Never write a function that explicitly returns null, and always check that the inputs aren't null before using them. [Fody NullGuard]


## Smart constructors
Is a function that takes a primitive type as input and returns Some or None to indicate the succesful creation of a custom type.
By providing a smart constructor, you can make the constructor private and you can ensure that the custom type is always created with valid data.


## Option type
An Option can be in one of two states:
* None: the absence of a value
* Some: a simple container wrapping a a non-null value


#### Separate pure logic from side effects

You should aim to separate pure logic from side effects =>  use Map for logic and ForEach for side effects

Option<string> optJohn = Some("John");
optJohn.ForEach(name => WriteLine($"Hello {name}"))

becomes (logic separated from side effects

optJohn.Map(name => $"Hello {name}".ForEach(WriteLine)


