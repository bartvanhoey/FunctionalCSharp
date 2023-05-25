# Functional error handling

Imperative programming uses the try/catch statement which disrupt the flow of the program, thus introducing side effects. It is not a good practice to use it in functional programming.

Functional programming strives to minimize side effects so throwing exceptions is generally avoided. 
Instead, the functional approach is to return an outcome that indicates whether the operation was successful or not.

IsSuccess 
    Result
IsFailure
    Error


## Either

The Either type has 2 possible Outcomes: Left (to indicate failure) and Right (to indicate success). 
Right is all right, but Left is not right.

Either has 2 generic type parameters: Either<L,R>: 
- Left wraps a value of type L (details about the error) 
- Right wraps a value of type T (successful result) 







