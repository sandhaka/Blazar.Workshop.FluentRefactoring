using System;

namespace SolarSystemsFactory.Refactored.Utils
{
    public class SolarSystemBuilderException : ArgumentException
    {
        public SolarSystemBuilderException(string message) : base(message)
        {

        }

        public string ComposedMessage => ResolveExceptionMessage(this);

        private static string ResolveExceptionMessage(Exception exception)
        {
            return exception.InnerException != null ? $"{exception.Message} -> {ResolveExceptionMessage(exception)}" : exception.Message;
        }
    }
}