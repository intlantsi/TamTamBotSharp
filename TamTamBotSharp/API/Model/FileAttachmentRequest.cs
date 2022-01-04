using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TamTamBot.API.Model
{
    /// <summary>
    /// Request to attach file to message. MUST be the only attachment in message
    /// </summary>
    public class FileAttachmentRequest : AttachmentRequest
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public FileAttachmentRequest()
        {

        }

        public FileAttachmentRequest(UploadedInfo payload) : base()
        {
            this.Payload = payload;
        }
        #endregion

        #region Properties
        [JsonPropertyName("payload")]
        public UploadedInfo Payload { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is FileAttachmentRequest)) return false;

            FileAttachmentRequest far = (FileAttachmentRequest) obj;
            return Object.Equals(this.Payload, far.Payload);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "FileAttachmentRequest{" + base.ToString()
            + " payload='" + Payload + '\''
            + '}';
        }
        #endregion
    }
}