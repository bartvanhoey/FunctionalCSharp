# FunctionalCSharp

## What is functional programming

## Imperative vs Functional programming


## Immutability / Immutable types

## Side effects

## Purity/Pure functions // mathematical functions

## Map

map is the name of a higher-order function that applies a given function to each element of a collection, e.g. a list or set, returning the results in a collection of the same type. 
It is often called apply-to-all when considered in functional form

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







## Reduce

## Tee

## Aggregate

## Pipelining

## Method chaining

## Extension methods

## Expressions instead of Statements

## Lazy evaluation

## Stateful computations

## Primitive Obsession

## Railway-oriented programming

## Currying

## Referential Transparency

## Higher-order functions(HOF)

## Functions are first-class citizens

## Memoization

## Lambda Expressions

Lambdas are used to declare a function inline. 

var list = Enumerable.Range(1, 10).Select(i => i * 3).ToList();
list // => [3, 6, 9, 12, 15, 18, 21, 24, 27, 30]

list.Sort((l, r) => l.ToString().CompareTo(r.ToString()));
list // => [12, 15, 18, 21, 24, 27, 3, 30, 6, 9]





## Function composition

## Closure

## Function Arity

Refers to the number of arguments that a function accepts:
* A nullary function takes no arguments.
* A unary function takes one argument.
* A binary function takes two arguments.
* A ternary function takes three arguments.
And so on. 

## Elvis operator // null coalescing operator

## Yield keyword

## Declarative programming vs imperative programming

## Partial application

## Monad

It’s a specific way of chaining operations together. In essence, you’re writing execution steps and linking them together with the “bind function”. (In Haskell, it’s named >>=.) You can write the calls to the bind operator yourself, or you can use syntax sugar which makes the compiler insert those function calls for you.

## Recursion

## Pattern matching

