using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class RequiredParameterMissingException : ClientException
    {
        public RequiredParameterMissingException(string message) : base(400, message) { }
    }
}
