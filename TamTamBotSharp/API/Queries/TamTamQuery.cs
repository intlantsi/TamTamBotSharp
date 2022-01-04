using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TamTamBot.API.Client;
using TamTamBot.API.Exceptions;

namespace TamTamBot.API.Queries
{
    public class TamTamQuery<T>:TamTamQuery
    {
        #region Fields
        private readonly TamTamClient tamTamClient;
        private readonly string url;
        private readonly object body;
        private readonly ITamTamTransportClient.MethodTypes method;
        #endregion

        #region Constructors
        public TamTamQuery(TamTamClient tamTamClient, string url)
            : this(tamTamClient, url, null, ITamTamTransportClient.MethodTypes.POST)
        {

        }

        public TamTamQuery(TamTamClient tamTamClient, string url, ITamTamTransportClient.MethodTypes method)
            : this(tamTamClient, url, null, method)
        {

        }

        public TamTamQuery(TamTamClient tamTamClient, string url, object body, ITamTamTransportClient.MethodTypes method)
        {
            this.tamTamClient = tamTamClient;
            this.url = url;
            this.body = body;
            this.method = method;
        }
        #endregion

        #region Properties
        public ITamTamTransportClient.MethodTypes Method { get => method; }
        public string URL { get => url; }
        public object Body { get => body; }
        public Type ResponseType { get => typeof(T); }
        #endregion

        #region Methods
        public override void AddParam(QueryParam param)
        {
            if (queryParams == null)
            {
                queryParams = new List<QueryParam>();
            }

            queryParams.Add(param);
        }

        public static string Substitute(string pathTemplate, params object[] substitutions)
        {
            StringBuilder sb = new StringBuilder();
            int nextSubst = 0;
            char[] chars = pathTemplate.ToCharArray();
            for (int i = 0; i < chars.Length; i++)
            {
                char c = chars[i];
                if (c == '{')
                {
                    i = pathTemplate.IndexOf('}', i);
                    sb.Append(substitutions[nextSubst++]);
                    continue;
                }
                sb.Append(c);
            }
            return sb.ToString();
        }

        public T Execute()
        {
            try
            {
                Task<T> clientTask=tamTamClient.CallAsync(this);
                clientTask.ConfigureAwait(false);
                return clientTask.Result;
            }
            catch (ThreadInterruptedException e)
            {
                throw new ClientException("Current request was interrupted", e);
            }
            catch (Exception e)
            {
                return Unwrap(e);
            }
        }

        public async Task<T> ExecuteAsync()
        {
            return await tamTamClient.CallAsync(this);
        }

        protected T Unwrap(Exception e)
        {
            Exception cause = e.InnerException;
            if (cause == null)
            {
                throw new ClientException(e);
            }

            if (cause is TransportClientException)
            {
                throw new ClientException(cause);
            }

            if (cause is APIException)
            {
                throw (APIException)cause;
            }

            if (cause is ClientException)
            {
                throw (ClientException)cause;
            }

            throw new ClientException(cause);
        }
        #endregion
    }

    public class TamTamQuery
    {

        #region Fields
        protected List<QueryParam> queryParams;
        //private readonly string url;
        #endregion

        #region Properties
        public List<QueryParam> Params { get => queryParams; }
        //public string URL { get => url; }
        #endregion

        #region Methods
        public virtual void AddParam(QueryParam param)
        {

        }


        #endregion

    }
}

