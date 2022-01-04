using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;
using TamTamBot.API.Client;

namespace TamTamBot.API.Queries.Upload
{
    public interface IUploadExec
    {
        Task<HttpResponseMessage> NewCall(ITamTamTransportClient transportClient);
    }
}
