using System;

namespace Training.Exceptions
{
    public class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
            : base(string.Empty)
        {

        }

        public InvalidCredentialsException(string message)
            : base(message)
        {

        }

        public InvalidCredentialsException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
