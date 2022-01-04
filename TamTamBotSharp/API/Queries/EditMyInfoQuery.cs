using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class EditMyInfoQuery : TamTamQuery<BotInfo>
    {
        public EditMyInfoQuery(TamTamClient client, BotPatch botPatch)
                : base(client, "/me", botPatch, ITamTamTransportClient.MethodTypes.PATCH)
        {

        }
    }
}
