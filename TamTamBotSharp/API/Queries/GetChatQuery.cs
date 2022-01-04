using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetChatQuery:TamTamQuery<Chat> 
    { 
        public GetChatQuery(TamTamClient client, long chatId)
            :base(client, Substitute("/chats/{chatId}", chatId), null, ITamTamTransportClient.MethodTypes.GET)
        {
            
        }
    }
}