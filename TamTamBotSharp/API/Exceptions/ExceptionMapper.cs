using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Model;


namespace TamTamBot.API.Exceptions
{
    public class ExceptionMapper
    {

        private ExceptionMapper() { }

        public static APIException Map(int statusCode, Error error)
        {
            string message = error.Message;
            switch (statusCode)
            {
                case 404:
                    return new NotFoundException(message);
                case 429:
                    return new TooManyRequestsException(message);
            }

            switch (error.Code)
            {
                case "proto.payload":
                    return new BadRequestException(message);
                case "attachment.not.ready":
                    return new AttachmentNotReadyException();
                case "access.denied":
                    return new AccessForbiddenException(message);
                case "chat.denied":
                    if ("chat.send.msg.no.permission.because.not.admin".Equals(message))
                    {
                        return new SendMessageForbiddenException(message);
                    }
                    return new ChatAccessForbiddenException(message);
            }

            return new APIException(statusCode, message);
        }
    }
}
