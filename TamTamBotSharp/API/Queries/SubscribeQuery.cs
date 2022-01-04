using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class SubscribeQuery : TamTamQuery<SimpleQueryResult>
    {
        public SubscribeQuery(TamTamClient client, SubscriptionRequestBody subscriptionRequestBody)
            :base(client, "/subscriptions", subscriptionRequestBody, ITamTamTransportClient.MethodTypes.POST)
        {
            
        }
    }
}


