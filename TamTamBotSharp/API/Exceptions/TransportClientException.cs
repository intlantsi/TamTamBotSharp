using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class TransportClientException : Exception
    {
        public TransportClientException(string message) : base(message) { }

        public TransportClientException(Exception cause) : base("Transport client excepton occured",cause) { }

        public TransportClientException(string message, Exception cause) : base(message, cause) { }
    }
}
