using System;

namespace Training.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base(string.Empty)
        {

        }

        public BadRequestException(string message)
            : base(message)
        {

        }

        public BadRequestException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
