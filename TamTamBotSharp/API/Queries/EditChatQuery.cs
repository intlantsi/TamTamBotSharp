using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class EditChatQuery : TamTamQuery<Chat>
    {
        public EditChatQuery(TamTamClient client, ChatPatch chatPatch, long chatId)
                : base(client, Substitute("/chats/{chatId}", chatId), chatPatch, ITamTamTransportClient.MethodTypes.PATCH)
        {

        }
    }
}
