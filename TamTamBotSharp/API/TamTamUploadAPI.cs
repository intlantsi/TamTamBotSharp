using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Queries.Upload;
using TamTamBot.API.Queries;
using TamTamBot.API.Model;
using TamTamBot.API.Exceptions;

namespace TamTamBot.API
{
    public class TamTamUploadAPI
    {
        private readonly TamTamClient client;

        public TamTamUploadAPI(TamTamClient client)
        {
            this.client = client;
        }

        public TamTamUploadFileQuery UploadFile(string url, FileStream file)
        {
            return new TamTamUploadFileQuery(client, url, file);
        }

        public TamTamUploadFileQuery UploadFile(string url, string fileName, Stream inputStream)
        {
            return new TamTamUploadFileQuery(client, url, fileName, inputStream);
        }

        public TamTamUploadImageQuery UploadImage(string url, FileStream file)
        {
            return new TamTamUploadImageQuery(client, url, file.Name, file);
        }

        public TamTamUploadImageQuery UploadImage(string url, string fileName, Stream inputStream)
        {
            return new TamTamUploadImageQuery(client, url, fileName, inputStream);
        }

        public TamTamUploadAVQuery UploadAV(string url, FileStream file)
        {
            return new TamTamUploadAVQuery(client, url, file);
        }

        public TamTamUploadAVQuery UploadAV(string url, String fileName, Stream inputStream)
        {
            return new TamTamUploadAVQuery(client, url, fileName, inputStream);
        }
    }
}
