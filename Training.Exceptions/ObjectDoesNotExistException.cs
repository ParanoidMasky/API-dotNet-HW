using System;

namespace Training.Exceptions
{
    public class ObjectDoesNotExistException : Exception
    {
        public ObjectDoesNotExistException()
            : base(string.Empty)
        {

        }

        public ObjectDoesNotExistException(string message)
            : base(message)
        {

        }

        public ObjectDoesNotExistException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
