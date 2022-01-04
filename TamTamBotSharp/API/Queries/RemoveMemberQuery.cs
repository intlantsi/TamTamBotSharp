using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class RemoveMemberQuery : TamTamQuery<SimpleQueryResult>
    {
        public readonly QueryParam<long> userIdParam;
        public readonly QueryParam<bool> blockParam;

        public RemoveMemberQuery(TamTamClient client, long chatId, long userId)
                : base(client, Substitute("/chats/{chatId}/members", chatId), null, ITamTamTransportClient.MethodTypes.DELETE)
        {
            userIdParam = new QueryParam<long>("user_id", this) { Required = true };
            blockParam = new QueryParam<bool>("block", this);
            this.userIdParam.Value = userId;
        }

        public RemoveMemberQuery Block(bool value)
        {
            this.blockParam.Value = value;
            return this;
        }
    }
}