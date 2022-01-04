using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetMembersQuery : TamTamQuery<ChatMembersList>
    {
        public readonly QueryParam<List<long>> userIds;
        public readonly QueryParam<long> marker;
        public readonly QueryParam<int> count;

        public GetMembersQuery(TamTamClient client, long chatId)
            : base(client, Substitute("/chats/{chatId}/members", chatId), null, ITamTamTransportClient.MethodTypes.GET)
        {
            userIds = new QueryParam<List<long>>("user_ids", this);
            marker = new QueryParam<long>("marker", this);
            count = new QueryParam<int>("count", this);
        }

        public List<long> UserIds
        {
            set
            {
                if (userIds.Value != value)
                    userIds.Value = value;
            }
        }

        public long Marker
        {
            set
            {
                if (marker.Value != value)
                    marker.Value = value;
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