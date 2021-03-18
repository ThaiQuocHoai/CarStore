using System;
using System.Collections.Generic;
using System.Text;

namespace Mercedes.Utilities.Exceptions
{
    public class MercedesException : Exception
    {
        public MercedesException()
        {
        }

        public MercedesException(string message)
            : base(message)
        {
        }

        public MercedesException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
