using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Exceptions
{
    public class ExpectationFailedException : Exception
    {
        public ExpectationFailedException()
            : base(string.Empty)
        {

        }

        public ExpectationFailedException(string message)
            : base(message)
        {

        }

        public ExpectationFailedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
