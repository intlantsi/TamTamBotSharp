using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetMessageByIdQuery : TamTamQuery<Message>
    {
        public GetMessageByIdQuery(TamTamClient client, String messageId)
            :base(client, Substitute("/messages/{messageId}", messageId), null, ITamTamTransportClient.MethodTypes.GET)
        {
            
        }
    }
}