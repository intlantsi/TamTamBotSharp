using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Exceptions
{
    public class AttachmentNotReadyException : APIException
    {
        public AttachmentNotReadyException() : base("You cannot send message with unprocessed attachment (video in most cases). Please try after a " +
                    "period of time. It depends on size of attachment.") { }
    }
}
