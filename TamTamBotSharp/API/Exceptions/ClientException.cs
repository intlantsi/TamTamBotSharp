using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class ClientException : Exception
    {
        private readonly int code;

        public ClientException(int code, string message) : base(message)
        {
            this.code = code;
        }

        public ClientException(Exception cause) : base("Client exception occured", cause)
        {
            this.code = 400;
        }

        public ClientException(string message, Exception cause) : base(message, cause)
        {
            this.code = 400;
        }
    }
}
