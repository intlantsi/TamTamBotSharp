using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using TamTamBot.API.Client;
using TamTamBot.API.Exceptions;

namespace TamTamBot.API.Queries.Upload
{
    public class FileUploadExec : IUploadExec
    {
        #region Fields
        private readonly FileStream file;
        private readonly string url;
        #endregion

        #region Constructor
        public FileUploadExec(string url, FileStream file)
        {
            this.url = url;
            this.file = file;
        }
        #endregion

        #region IUploadExec impl
        public async Task<HttpResponseMessage> NewCall(ITamTamTransportClient transportClient)
        {
            try
            {
                return await transportClient.PostAsync(url, file);
            }
            catch (TransportClientException e)
            {
                throw new ClientException(e);
            }
        }
        #endregion

    }
}
