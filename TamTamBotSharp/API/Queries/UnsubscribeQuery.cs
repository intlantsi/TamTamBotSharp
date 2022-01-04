using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class UnsubscribeQuery : TamTamQuery<SimpleQueryResult>
    {
        public readonly QueryParam<String> urlParam;

        public UnsubscribeQuery(TamTamClient client, string url)
                : base(client, "/subscriptions", null, ITamTamTransportClient.MethodTypes.DELETE)
        {
            urlParam = new QueryParam<String>("url", this) { Required = true };
            this.urlParam.Value = url;
        }
    }
}