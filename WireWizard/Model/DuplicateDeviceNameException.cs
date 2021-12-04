using System;
using System.Runtime.Serialization;

namespace WireWizard
{
    [Serializable]
    public class DuplicateDeviceNameException : ArgumentException
    {
        public DuplicateDeviceNameException()
        {

        }
        public DuplicateDeviceNameException(string message) : base(message)
        {

        }
        public DuplicateDeviceNameException(string message, Exception innerException) : base(message, innerException)
        {

        }
        protected DuplicateDeviceNameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {

        }
    }
}
