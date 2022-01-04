using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class APIException : Exception
    {
        private readonly int statusCode;

        public APIException(string message) : this(400, message) { }

        public APIException(int statusCode) : this(503, "Unexpected server error: " + statusCode) { }

        public APIException(int statusCode, string message) : base(message)
        {
            this.statusCode = statusCode;
        }

        public int StatusCode { get => statusCode; }
    }
}
