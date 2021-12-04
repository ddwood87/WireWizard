using System;
using System.Runtime.Serialization;

namespace WireWizard
{
    [Serializable]
    public class NoCallBackException : Exception
    {
        
        public NoCallBackException()
        {
            
        }

        public NoCallBackException(string message) : base(message)
        {
        }

        public NoCallBackException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NoCallBackException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}