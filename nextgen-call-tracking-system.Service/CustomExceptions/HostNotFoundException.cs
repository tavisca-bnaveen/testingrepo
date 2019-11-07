using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace nextgen_call_tracking_system.Service.CustomExceptions
{
    [Serializable]
    public class HostNotFoundException : Exception
    {
        public HostNotFoundException()
        {
        }

        public HostNotFoundException(string message) : base(message)
        {
        }

        public HostNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected HostNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
