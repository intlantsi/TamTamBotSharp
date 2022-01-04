using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetChatByLinkQuery : TamTamQuery<Chat>
    {
        public GetChatByLinkQuery(TamTamClient client, string chatLink)
                : base(client, Substitute("/chats/{chatLink}", chatLink), null, ITamTamTransportClient.MethodTypes.GET)
        {

        }
    }
}