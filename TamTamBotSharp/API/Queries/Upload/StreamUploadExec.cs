using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Http;
using TamTamBot.API.Client;
using TamTamBot.API.Exceptions;

namespace TamTamBot.API.Queries.Upload
{
    public class StreamUploadExec:IUploadExec
    {
        #region Fields
        private readonly string fileName;
        private readonly Stream input;
        private readonly string url;
        #endregion

        #region Constructor
        public StreamUploadExec(string url, string fileName, Stream input)
        {
            this.url = url;
            this.fileName = fileName;
            this.input = input;
        }
        #endregion

        #region IUploadExec impl
        public async Task<HttpResponseMessage> NewCall(ITamTamTransportClient transportClient)
        {
            try
            {
                return await transportClient.PostAsync(url, fileName, input);
            }
            catch (TransportClientException e)
            {
                throw new ClientException(e);
            }
        }
        #endregion
    }
}
