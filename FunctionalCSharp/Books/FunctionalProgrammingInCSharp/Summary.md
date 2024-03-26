# Part1: Core Concepts

## Chapter 1: Functional Programming

### What is Functional Programming

FP is as programming paradigm: a different way of thinking about programs than the imperative style.
A programming style that emphasizes functions while avoiding state mutation

* Functions are first-class values
* Avoiding state mutation

#### Functions are first-class values

you can use them as inputs or outputs of other functions, you can assign them to variables, ...

#### Avoiding state mutation

In FP we should avoid state mutation. 
once created, an object never changes, and variables should never be reassigned.

Sorting/Filtering a list should not modify the list in place, but return a new list.

##### LINQ is a good example of FP in C#.

```csharp
    Enumerable.Range(1, 100).Where(i => i % 20 == 0).OrderBy(i => -i).Select(i => $"{i}%")
    // => ["100%", "80%", "60%", "40%", "20%"]
```

Where (Filtering), OrderBy(Sorting), and Select(Mapping) all take functions as arguments and don’t
mutate the given IEnumerable, but return a new IEnumerable instead.

* Where: Filtering
 ```csharp
  Enumerable.Range(1, 10).Where(i => i % 3 == 0) // => [3, 6, 9]
 ```

* OrderBy: Sorting
 ```csharp
     Enumerable.Range(1, 5).OrderBy(i => -i) // => [5, 4, 3, 2, 1]
 ```

* Select: Mapping
 ```csharp
  Enumerable.Range(1, 3).Select(i => i * 3) // => [3, 6, 9]
 ```



### Thinking in functions

#### Functions as maps
#### Representing functions in C#

* Methods
* Delegates
  
Evolution of .NET has been away from custom delegates, in favor of the more general Func and Action delegates.
* 
* Lambda expressions (Lambdas, are used to declare a function inline)
* Dictionaries

### Higher-order functions (HOFs)

#### Functions that depend on other functions

HOFs are functions that take other functions as inputs or return a function as output, or both.

#### Adapter functions

#### Using HOFs to avoid duplication

Encapsulating setup and teardown into a HOF. Writing a function that performs setup and teardown around a given function.
This pattern is inelegantly called "hole in the middle" in the book.

```csharp
    public static T Connect<T>(string connectionString, Func<IDbConnection, T> func)
    {
      using var conn = new SqlConnection(connectionString);
      conn.Open();
      return func(conn);
    }
```

#### Benefits of Functional Programming

* Conciseness -> same result with fewer lines of code
* Cleaner code -> more expressive, more readable and more maintainable code
* Better support for concurrency
* A multi-paradigm approach
If the only tool you have is a hammer, everything looks like a nail. 
If you know Functional Programming, you'll be able to consider several different approaches to a problem and choose the best one.


# Chapter 3: Designing functions signatures and types

Functions are the building blocks of functional programs. Getting the signature right is crucial.

### Function signature design

#### Arrow notation

Arrow notation for expressing function signatures in C# = Lingua Franca for FP in C#.

Function signature             |   C# type                    | Example
===============================|==============================|====================
int -> string                  | Func<int,string>             | (int i) => i.ToString()
() -> string                   | Func<string>                 | () => "hello" // returns a string
int -> ()                      | Action<int>                  | (int) => Console.WriteLine($"gimme {i}") // void
() => ()                       | Action                       | () => Console.WriteLine("hello") // void
(int,int) => (int)             | Func<int,int,int>            | (int a, int b) => a + b

examples arrow notation:

1. (string, (IDbConnection -> R)) -> R  => Func<string, Func<IDbConnection,R>, R>

  ```csharp
    public static R Connect<R>(string connStr, Func<IDbConnection, R> func)
    => Using(new SqlConnection(connStr)
    , conn => { conn.Open(); return func(conn); });
  ```

2. (IEnumerable<T>, (T -> bool)) -> IEnumerable<T>

  The function returns a list of T's as output, and takes a list of T's as input,
  as well as a second argument which is a function from T to bool: a predicate on T.

```csharp
  public static IEnumerable<T> Filter<T>(this IEnumerable<T> items, Func<T, bool> predicate)
  => items.Where(predicate);
```

3. (IEnumerable<A>, IEnumerable<B>, ((A, B) => C)) => IEnumerable<C>

### Capturing data with data objects 

Primitives are often not specific enough.

#### Constraining inputs with Custom Types (Value Objects instead of Primitives) 

### Modeling the absence of data with Unit

Why can’t we just use Func<Void> to represent a function that returns nothing, 
just as we use Func<string> to represent a function that returns a string.

The framework has the void keyword to represent 'no return value', but cannot be used a return type.


### Modeling the possible absence of data with Option (Maybe)

Option<T> = None | Some(T) => Can be one of 2 things

None: Option None, absence of a value
Some(T): The Option has an inner Value of T, the option is Some


