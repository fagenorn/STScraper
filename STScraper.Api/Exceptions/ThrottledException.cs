using System;

namespace STScraper.Api.Exceptions
{
    public class ThrottledException : STScraperException
    {
        internal ThrottledException() { }

        internal ThrottledException(string message) : base(message) { }

        internal ThrottledException(string format, params object[] args) : base(string.Format(format, args)) { }

        internal ThrottledException(string message, Exception innerException) : base(message, innerException) { }

        internal ThrottledException(string format, Exception innerException, params object[] args) : base(string.Format(format, args), innerException) { }
    }
}