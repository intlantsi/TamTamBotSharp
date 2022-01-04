using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetSubscriptionsQuery : TamTamQuery<GetSubscriptionsResult>
    {
        public GetSubscriptionsQuery(TamTamClient client)
            :base(client, "/subscriptions", null, ITamTamTransportClient.MethodTypes.GET)
        {
            
        }
    }
}