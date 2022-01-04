using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class PinMessageQuery : TamTamQuery<SimpleQueryResult>
    {
        public PinMessageQuery(TamTamClient client, PinMessageBody pinMessageBody, long chatId)
                : base(client, Substitute("/chats/{chatId}/pin", chatId), pinMessageBody, ITamTamTransportClient.MethodTypes.PUT)
        {

        }
    }
}



