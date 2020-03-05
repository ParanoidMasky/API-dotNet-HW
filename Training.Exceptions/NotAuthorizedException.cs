using System;

namespace Training.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException()
            : base(string.Empty)
        {

        }

        public NotAuthorizedException(string message)
            : base(message)
        {

        }

        public NotAuthorizedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
