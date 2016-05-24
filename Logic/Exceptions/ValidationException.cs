using System;

namespace Logic.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException()
            : base(String.Format("Feed data could not be loaded, URL is invalid.")) { }
    }
}