using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using TamTamBot.API.Model;
using TamTamBot.API.Client;
using TamTamBot.API.Exceptions;

namespace TamTamBot.API.Queries.Upload
{
    public class TamTamUploadImageQuery : TamTamUploadQuery<PhotoTokens>
    {
        public TamTamUploadImageQuery(TamTamClient tamTamClient, string url, string fileName, Stream input)
            : base(tamTamClient, url, fileName, input)
        {

        }
    }
}