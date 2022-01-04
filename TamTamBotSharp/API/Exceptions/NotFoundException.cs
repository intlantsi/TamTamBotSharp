using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class NotFoundException : APIException
    {
        public NotFoundException(string message) : base(404, message)
        {

        }
    }
}
