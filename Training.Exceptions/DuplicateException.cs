using System;
using System.Collections.Generic;
using System.Text;

namespace Training.Exceptions
{
    public class DuplicateException : Exception
    {
        public DuplicateException()
            : base(string.Empty)
        {

        }

        public DuplicateException(string message)
            : base(message)
        {

        }

        public DuplicateException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
