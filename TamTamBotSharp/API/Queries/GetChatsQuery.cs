using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetChatsQuery : TamTamQuery<ChatList>
    {
        public readonly QueryParam<int> count;
        public readonly QueryParam<long> marker;

        public GetChatsQuery(TamTamClient client) : base(client, "/chats", null, ITamTamTransportClient.MethodTypes.GET)
        {
            count = new QueryParam<int>("count", this);
            marker = new QueryParam<long>("marker", this);
        }

        public int Count 
        { 
            set
            {
                if (count.Value != value)
                    count.Value = value;
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
    }
}