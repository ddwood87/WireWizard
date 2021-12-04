using System;
using System.Runtime.Serialization;

namespace WireWizard
{
    [Serializable]
    internal class TerminalFullException : Exception
    {
        public TerminalFullException()
        {
        }

        public TerminalFullException(string message) : base(message)
        {
        }

        public TerminalFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TerminalFullException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
