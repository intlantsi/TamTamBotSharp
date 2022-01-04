using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class ChatAccessForbiddenException : APIException
    {
        public ChatAccessForbiddenException(string message) : base(403, message) { }
    }
}
