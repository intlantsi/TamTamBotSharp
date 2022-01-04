using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetMyInfoQuery : TamTamQuery<BotInfo>
    {
        public GetMyInfoQuery(TamTamClient client)
                : base(client, "/me", null, ITamTamTransportClient.MethodTypes.GET)
        {
            
        }
    }
}