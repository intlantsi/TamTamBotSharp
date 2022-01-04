using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class AddMembersQuery : TamTamQuery<SimpleQueryResult>
    {
        public AddMembersQuery(TamTamClient client, UserIdsList userIdsList, long chatId)
            :base(client, Substitute("/chats/{chatId}/members", chatId), userIdsList, ITamTamTransportClient.MethodTypes.POST)
        {
            
        }
    }
}




