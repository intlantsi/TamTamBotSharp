using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class DeleteMessageQuery : TamTamQuery<SimpleQueryResult>
    {
        public readonly QueryParam<string> messageIdParam;

        public DeleteMessageQuery(TamTamClient client, string messageId)
            : base(client, "/messages", null, ITamTamTransportClient.MethodTypes.DELETE)
        {
            messageIdParam = new QueryParam<string>("message_id", this) { Required = true };
            this.messageIdParam.Value = messageId;
        }
    }
}