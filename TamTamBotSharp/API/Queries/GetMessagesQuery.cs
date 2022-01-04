using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetMessagesQuery : TamTamQuery<MessageList>
    {
        public readonly QueryParam<long> chatId;
        public readonly QueryParam<List<string>> messageIds;
        public readonly QueryParam<long> from;
        public readonly QueryParam<long> to;
        public readonly QueryParam<int> count;

        public GetMessagesQuery(TamTamClient client)
                : base(client, "/messages", null, ITamTamTransportClient.MethodTypes.GET)
        {
            chatId = new QueryParam<long>("chat_id", this);
            messageIds = new QueryParam<List<string>>("message_ids", this);
            from = new QueryParam<long>("from", this);
            to = new QueryParam<long>("to", this);
            count = new QueryParam<int>("count", this);
        }


        public long ÑhatId
        {
            set
            {
                if (chatId.Value != value)
                    chatId.Value = value;
            }
        }

        public List<string> MessageIds
        {
            set
            {
                if (messageIds.Value != value)
                    messageIds.Value = value;
            }
        }

        public long From
        {
            set
            {
                if (from.Value != value)
                    from.Value = value;
            }
        }

        public long To
        {
            set
            {
                if (to.Value != value)
                    to.Value = value;
            }
        }

        public int Count
        {
            set
            {
                if (count.Value != value)
                    count.Value = value;
            }
        }
    }
}