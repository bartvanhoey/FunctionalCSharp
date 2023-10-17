namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors.Factory
{
    public static class ResultErrorFactory
    {
        public static CannotReserveOnAPastDateResultError CannotReserveOnAPastDate => new();

        public static UnableToConnectToTheTheaterResultError UnableToConnectToTheTheater => new();
        
        public static TicketsOnThisDateNoLongerAvailableResultError TicketsOnThisDateNoLongerAvailable => new();

        public static IncorrectCustomerNameResultError IncorrectCustomerName => new();

        public static EmailEmptyResultError EmailEmpty => new();

        public static EmailTooLongResultError EmailTooLong => new();

        public static EmailInvalidResultError EmailInvalid => new();
        

        public static CustomerNameEmptyResultError CustomerNameEmpty => new();
        public static CustomerNameTooLongResultError CustomerNameTooLong => new();
        public static CustomerByIdNotFoundResultError CustomerByIdNotFound(long id) => new(id);
        public static CustomerHasHighestStatusPossibleResultError CustomerHasHighestStatusPossible() => new();
        
        public static MoneyAmountIsInvalidResultError MoneyAmountIsInvalid => new();
        public static ChargedFailedResultError ChargedFailed => new();
        public static UnableToConnectToDatabaseResultError UnableToConnectToDatabase => new();
        
    }
}