using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Model;

namespace TamTamBot.API.Queries
{
    public class GetUploadUrlQuery : TamTamQuery<UploadEndpoint>
    {
        public readonly QueryParam<UploadTypes> typeParam;

        public GetUploadUrlQuery(TamTamClient client, UploadTypes type)
                : base(client, "/uploads", null, ITamTamTransportClient.MethodTypes.POST)
        {
            typeParam = new QueryParam<UploadTypes>("type", this) { Required = true };
            this.typeParam.Value = type;
        }
    }
}