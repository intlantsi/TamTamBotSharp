using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class SendActionQuery : TamTamQuery<SimpleQueryResult>
    {
        public SendActionQuery(TamTamClient client, ActionRequestBody actionRequestBody, long chatId)
                : base(client, Substitute("/chats/{chatId}/actions", chatId), actionRequestBody, ITamTamTransportClient.MethodTypes.POST)
        {

        }
    }
}