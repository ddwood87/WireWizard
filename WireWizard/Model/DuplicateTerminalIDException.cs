using System;
using System.Runtime.Serialization;

namespace WireWizard
{
    public class DuplicateTerminalIDException : Exception
    {
        public DuplicateTerminalIDException()
        {
        }

        public DuplicateTerminalIDException(string message) : base(message)
        {
        }

        public DuplicateTerminalIDException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DuplicateTerminalIDException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
