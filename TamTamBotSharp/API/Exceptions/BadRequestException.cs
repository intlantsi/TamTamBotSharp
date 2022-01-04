using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TamTamBot.API.Exceptions
{
    public class BadRequestException : APIException
    {
        public BadRequestException(string message) : base(message) { }
    }
}
