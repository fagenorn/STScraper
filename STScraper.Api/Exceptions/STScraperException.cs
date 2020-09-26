using System;

namespace STScraper.Api.Exceptions
{
    public class STScraperException : Exception
    {
        internal STScraperException() { }

        internal STScraperException(string message) : base(message) { }

        internal STScraperException(string format, params object[] args) : base(string.Format(format, args)) { }

        internal STScraperException(string message, Exception innerException) : base(message, innerException) { }

        internal STScraperException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
    }
}