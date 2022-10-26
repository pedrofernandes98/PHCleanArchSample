namespace PHCleanArchSample.Domain.Validation
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string errorMessage) : base(errorMessage) { }

        public static void When(bool hasError, string message)
        {
            if (hasError)
                throw new DomainValidationException(message);
        }
    }
}
