using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetUpdatesQuery : TamTamQuery<UpdateList>
    {
        public readonly QueryParam<int> limit;
        public readonly QueryParam<int> timeout;
        public readonly QueryParam<long> marker;
        public readonly QueryParam<List<string>> types;

        public GetUpdatesQuery(TamTamClient client)
                : base(client, "/updates", null, ITamTamTransportClient.MethodTypes.GET)
        {
            limit = new QueryParam<int>("limit", this);
            timeout = new QueryParam<int>("timeout", this);
            marker = new QueryParam<long>("marker", this);
            types = new QueryParam<List<string>>("types", this);
        }

        public int Limit
        {
            set
            {
                if (limit.Value != value)
                    limit.Value = value;
            }
        }

        public int Timeout
        {
            set
            {
                if (timeout.Value != value)
                    timeout.Value = value;
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

        public List<string> Types
        {
            set
            {
                if (types.Value != value)
                    types.Value = value;
            }
        }
    }
}