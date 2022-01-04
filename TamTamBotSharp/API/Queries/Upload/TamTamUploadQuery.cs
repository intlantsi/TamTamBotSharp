using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using TamTamBot.API.Client;
using TamTamBot.API.Exceptions;

namespace TamTamBot.API.Queries.Upload
{
    public abstract class TamTamUploadQuery<T>:TamTamQuery<T>
    {
        #region Fields
        private readonly IUploadExec uploadExec;
        private readonly TamTamClient tamTamClient;
        #endregion

        #region Constructor
        public TamTamUploadQuery(TamTamClient tamTamClient, string url, FileStream file):base(tamTamClient, url)
        {
            this.tamTamClient = tamTamClient;
            this.uploadExec = new FileUploadExec(url, file);
        }

        public TamTamUploadQuery(TamTamClient tamTamClient, string url, string fileName,Stream input):base(tamTamClient,url)
        {
            this.tamTamClient = tamTamClient;
            this.uploadExec = new StreamUploadExec(url, fileName, input);
        }
        #endregion

        #region Properties
        public IUploadExec UploadExec { get => uploadExec; }
        #endregion

        #region Methods
        public async Task<T> ExecuteAsync()
        {
            return await tamTamClient.CallAsync(this);
        }

        public T Execute()
        {
            try
            {
                Task<T> clientTask = tamTamClient.CallAsync(this);
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
        #endregion
    }
}
