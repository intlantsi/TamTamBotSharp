using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class SendMessageQuery : TamTamQuery<SendMessageResult>
    {
        public readonly QueryParam<long> userId;
        public readonly QueryParam<long> chatId;
        public readonly QueryParam<bool> disableLinkPreview;

        public SendMessageQuery(TamTamClient client, NewMessageBody newMessageBody)
                : base(client, "/messages", newMessageBody, ITamTamTransportClient.MethodTypes.POST)
        {
            userId = new QueryParam<long>("user_id", this);
            chatId = new QueryParam<long>("chat_id", this);
            disableLinkPreview = new QueryParam<bool>("disable_link_preview", this);
        }

        public long UserId
        {
            set
            {
                if (userId.Value != value)
                    userId.Value = value;
            }
        }

        public long ChatId
        {
            set
            {
                if (chatId.Value != value)
                    chatId.Value = value;
            }
        }

        public bool DisableLinkPreview
        {
            set
            {
                if (disableLinkPreview.Value != value)
                    disableLinkPreview.Value = value;
            }
        }
    }
}