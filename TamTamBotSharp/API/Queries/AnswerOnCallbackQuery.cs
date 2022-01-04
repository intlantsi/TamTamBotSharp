using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class AnswerOnCallbackQuery : TamTamQuery<SimpleQueryResult>
    {
        public readonly QueryParam<string> callbackIdParam;

        public AnswerOnCallbackQuery(TamTamClient client, CallbackAnswer callbackAnswer, string callbackId)
                : base(client, "/answers", callbackAnswer, ITamTamTransportClient.MethodTypes.POST)
        {
            callbackIdParam = new QueryParam<string>("callback_id", this) { Required = true };
            this.callbackIdParam.Value=callbackId;
        }
    }
}