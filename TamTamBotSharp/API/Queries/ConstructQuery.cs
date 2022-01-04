using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class ConstructQuery : TamTamQuery<SimpleQueryResult>
    {
        public readonly QueryParam<string> sessionIdParam;

        public ConstructQuery(TamTamClient client, ConstructorAnswer constructorAnswer, string sessionId)
            :base(client, "/answers/constructor", constructorAnswer,ITamTamTransportClient.MethodTypes.POST)
        {
            sessionIdParam = new QueryParam<string>("session_id", this) { Required = true };
            this.sessionIdParam.Value = sessionId;
        }

    }
}