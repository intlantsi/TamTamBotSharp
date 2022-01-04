using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class EditMessageQuery : TamTamQuery<SimpleQueryResult>
    {
        public readonly QueryParam<string> messageParamId;

        public EditMessageQuery(TamTamClient client, NewMessageBody newMessageBody, string messageId)
            : base(client, "/messages", newMessageBody, ITamTamTransportClient.MethodTypes.PUT)
        {
            messageParamId = new QueryParam<string>("message_id", this) { Required = true };
            this.messageParamId.Value = messageId;
        }
    }
}