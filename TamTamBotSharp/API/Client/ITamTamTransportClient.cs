using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.IO;

namespace TamTamBot.API.Client
{
    public interface ITamTamTransportClient
    {
        Task<HttpResponseMessage> GetAsync(string url);
        Task<HttpResponseMessage> PostAsync(string url, byte[] body);
        Task<HttpResponseMessage> PostAsync(string url, FileStream file);
        Task<HttpResponseMessage> PostAsync(string url, string filename, Stream input);
        Task<HttpResponseMessage> PutAsync(string url, byte[] requestBody);
        Task<HttpResponseMessage> DeleteAsync(string url);
        Task<HttpResponseMessage> PatchAsync(string url, byte[] requestBody);

        enum MethodTypes
        {
            GET, 
            POST, 
            PUT, 
            HEAD, 
            DELETE, 
            PATCH, 
            OPTIONS
        }
    }
}
