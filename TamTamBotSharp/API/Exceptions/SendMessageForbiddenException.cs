using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class SendMessageForbiddenException : APIException
    {
        public SendMessageForbiddenException(string message) : base(message) { }
    }
}
