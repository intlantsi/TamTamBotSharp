using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class SerializationException : ClientException
    {
        public SerializationException(Exception exc) : base(exc) { }
    }
}
