# Side Effects

Side effects in programming refer to any application state changes that occur outside the function
being executed. 

These changes could include modifying a global or static variable, changing the
original value of function parameters, performing I/O operations, or even throwing an exception.
Side effects make the behavior of a function dependent on the context, reducing predictability and
potentially increasing bugs.

## Common sources of Side Effects

* Global Variables
* The out and ref parameters
* I/O operations
* Exception Handling

## Consequences of Side Effects

### Decreased predictability: 

Functions with side effects are less predictable because their output can
change based on the external state. This decreased predictability makes it harder to understand
what a function does just by looking at it.

### Increased difficulty in testing and debugging: 

Functions with side effects are harder to test
since they require the correct external state to produce the expected result. Debugging is also
more complex because an issue in the function could be due to an external state change.

### Concurrency issues: 

Concurrency problems can arise when multiple threads access and modify
shared state simultaneously, leading to unexpected results.

## How to minimize Side Effects

### Favor Immutability

### Use readonly and const

readonly and const are two keywords in C# that can make your fields and variables unchangeable,
thereby reducing the potential for side effects.

### Use functional programming principles

Expressions over statements, use of higher-order functions, function composition, ...

### Encapsulate Side Effects

Side effects are unavoidable, but you can try to isolate them. 
For instance, if a function must write toa file, that should be its sole responsibility. 
All other logic should be separated into pure functions as much as possible. 
This way, the side effects are contained, and the rest of your code remains unaffected





