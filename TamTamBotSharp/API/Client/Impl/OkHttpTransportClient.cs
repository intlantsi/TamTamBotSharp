using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TamTamBot.API.Client.Impl
{
    class OkHttpTransportClient : ITamTamTransportClient
    {
        #region Fields
        HttpClient client;
        private static readonly int TwoMb = 2_048_000;
        #endregion

        #region Constructor
        public OkHttpTransportClient()
        {
            client = new HttpClient();
        }
        #endregion

        #region ITamTamTransportClient implementation
        public async Task<HttpResponseMessage> GetAsync(string url)
        {
            return await client.GetAsync(url);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, byte[] body)
        {
            ByteArrayContent content = new ByteArrayContent(body);
            return await client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> PostAsync(string url, FileStream file)
        {
            HttpResponseMessage resp=new HttpResponseMessage();
            byte[] buffer = new byte[TwoMb];
            int read;
            int from = 0;
            int to = 0;
            
            while ((read = file.Read(buffer)) != 0)
            {
                int nextTo = from + read;
                to = nextTo ==file.Length? nextTo-1 : nextTo;

                ByteArrayContent content = new ByteArrayContent(buffer, 0, read);
                content.Headers.ContentRange = new ContentRangeHeaderValue(from, to, file.Length);
                content.Headers.Add("X-Requested-With", "XMLHttpRequest");
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                {
                    FileName = Path.GetFileName(file.Name)
                };

                resp=await client.PostAsync(url, content);
                from = to;
            }
            return resp;
        }

        public async Task<HttpResponseMessage> PostAsync(string url, string filename, Stream input)
        {
            StreamContent content = new StreamContent(input);
            MultipartFormDataContent formData = new MultipartFormDataContent();

            formData.Add(content, "v1", Path.GetFileName(filename));
            return await client.PostAsync(url, formData);
        }

        public async Task<HttpResponseMessage> PutAsync(string url, byte[] requestBody)
        {
            ByteArrayContent content = new ByteArrayContent(requestBody);
            return await client.PostAsync(url, content);
        }

        public async Task<HttpResponseMessage> PatchAsync(string url, byte[] requestBody)
        {
            ByteArrayContent content = new ByteArrayContent(requestBody);
            return await client.PatchAsync(url, content);
        }

        public async Task<HttpResponseMessage> DeleteAsync(string url)
        {
            return await client.DeleteAsync(url);
        }
        #endregion

    }
}
