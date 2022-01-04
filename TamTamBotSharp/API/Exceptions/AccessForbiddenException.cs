using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class AccessForbiddenException:APIException
    {
        public AccessForbiddenException(string message):base(message)
        {
            
        }
    }
}
