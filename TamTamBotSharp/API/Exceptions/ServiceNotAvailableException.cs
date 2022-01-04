using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class ServiceNotAvailableException : ClientException
    {
        public ServiceNotAvailableException(string message) : base(503, "Service not available. Please try later. " + message) { }
    }
}
