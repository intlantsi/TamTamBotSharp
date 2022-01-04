using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using TamTamBot.API;
using TamTamBot.API.Client.Impl;
using TamTamBot.API.Queries;
using TamTamBot.API.Exceptions;
using TamTamBot.API.Model;
using TamTamBot.API.Queries.Upload;

namespace TamTamBot.API.Client
{
    public class TamTamClient
    {
        #region Fields
        static readonly string ENDPOINT_ENV_VAR_NAME = "TAMTAM_BOTAPI_ENDPOINT";
        private static readonly string ENDPOINT = "https://botapi.tamtam.chat";
        private readonly string accessToken;
        private readonly ITamTamTransportClient transport;
        private readonly ITamTamSerializer serializer;
        private readonly string endpoint;
        #endregion

        public TamTamClient(string accessToken, ITamTamTransportClient transport, ITamTamSerializer serializer)
        {
            this.endpoint = CreateEndpoint();
            this.accessToken = accessToken ?? throw new ArgumentNullException("Mandatory parameter", nameof(accessToken));
            this.transport = transport ?? throw new ArgumentNullException("Mandatory parameter", nameof(transport));
            this.serializer = serializer ?? throw new ArgumentNullException("Mandatory parameter", nameof(serializer));
        }

        public static TamTamClient Create(string accessToken)
        {
            if (String.IsNullOrEmpty(accessToken))
                throw new NullReferenceException("No access token given. Get it using https://tt.me/primebot");

            OkHttpTransportClient transport = new OkHttpTransportClient();
            JacksonSerializer serializer = new JacksonSerializer();
            return new TamTamClient(accessToken, transport, serializer);
        }

        #region Properties
        public string Endpoint { get => endpoint; }
        public string AccessToken { get => accessToken; }
        public ITamTamSerializer Serializer { get => serializer; }
        public ITamTamTransportClient Transport { get => transport; }
        #endregion

        #region Methods
        public async Task<T> CallAsync<T>(TamTamUploadQuery<T> query)
        {
            var resp=await query.UploadExec.NewCall(Transport);
            string ans = await resp.Content.ReadAsStringAsync();
            return Serializer.Deserialize<T>(ans);
        }

        public async Task<T> CallAsync<T>(TamTamQuery<T> query)
        {
            ITamTamTransportClient.MethodTypes method = query.Method;
            string url = BuildURL(query);
            byte[] requestBody = Serializer.Serialize(query.Body);

            HttpResponseMessage response;
            try
            {
                switch (method)
                {
                    case ITamTamTransportClient.MethodTypes.GET:
                        response = await Transport.GetAsync(url);
                        break;
                    case ITamTamTransportClient.MethodTypes.POST:
                        response = await Transport.PostAsync(url, requestBody);
                        break;
                    case ITamTamTransportClient.MethodTypes.PUT:
                        response = await Transport.PutAsync(url, requestBody);
                        break;
                    case ITamTamTransportClient.MethodTypes.DELETE:
                        response = await Transport.DeleteAsync(url);
                        break;
                    case ITamTamTransportClient.MethodTypes.PATCH:
                        response = await Transport.PatchAsync(url, requestBody);
                        break;
                    default:
                        throw new ClientException(400, "Method " + method.ToString() + " is not supported.");
                }
                return await HandleResponse<T>(response);
            }
            catch (TransportClientException e)
            {
                throw new ClientException(e);
            }

            //return default(T);
        }

        public string BuildURL<T>(TamTamQuery<T> query)
        {
            string url = query.URL;
            StringBuilder sb = new StringBuilder(url);
            if (url.Length < 4 || !(url.Substring(0, 4) == "http"))
            {
                sb.Insert(0, Endpoint);
            }

            if (url.IndexOf('?') == -1)
            {
                sb.Append('?');
            }
            else
            {
                sb.Append('&');
            }

            sb.Append("access_token=").Append(AccessToken);
            sb.Append('&');
            sb.Append("v=").Append(TamTamAPIVersion.GetVersion);

            List<QueryParam> prms = query.Params;
            if (prms == null)
            {
                return sb.ToString();
            }

            foreach (QueryParam prm in prms)
            {
                string name = prm.Name;
                if (prm.QueryParamValue == null)
                {
                    if (prm.Required)
                    {
                        throw new RequiredParameterMissingException("Required param " + name + " is missing.");
                    }
                    continue;
                }

                sb.Append('&');
                sb.Append(name);
                sb.Append('=');
                try
                {
                    sb.Append(EncodeParam(prm.QueryParamValue.ToString()));
                }
                catch (Exception e)
                {
                    throw new ClientException(e);
                }
            }

            return sb.ToString();
        }


        protected string EncodeParam(string paramValue)
        {
            return HttpUtility.UrlEncode(paramValue, Encoding.UTF8);
        }

        private async Task<T> HandleResponse<T>(HttpResponseMessage response)
        {
            string responseBody = await response.Content.ReadAsStringAsync();
            if (response.StatusCode == (HttpStatusCode)503)
            {
                throw new ServiceNotAvailableException(responseBody);
            }
            if (((int)response.StatusCode) / 100 == 2)
            {
                return Serializer.Deserialize<T>(responseBody);
            }

            Error error;
            try
            {
                error = serializer.Deserialize<Error>(responseBody);
            }
            catch (SerializationException e)
            {
                throw new APIException((int)response.StatusCode, responseBody);
            }

            if (error == null)
            {
                throw new APIException((int)response.StatusCode);
            }

            throw ExceptionMapper.Map((int)response.StatusCode, error);
        }

        private string CreateEndpoint()
        {
            string env = Environment.GetEnvironmentVariable(ENDPOINT_ENV_VAR_NAME);
            if (env != null)
            {
                return env;
            }

            return ENDPOINT;
        }
        #endregion

    }
}
