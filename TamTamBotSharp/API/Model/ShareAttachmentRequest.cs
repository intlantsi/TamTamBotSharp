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
    /// Request to attach media preview of any external URL
    /// </summary>
    public class ShareAttachmentRequest:AttachmentRequest
    {
        #region Fields
        
        #endregion

        #region Constructor
        [JsonConstructor]
        public ShareAttachmentRequest():base()
        {

        }

        public ShareAttachmentRequest(ShareAttachmentPayload payload) : base()
        {
            this.Payload = payload;
        }
        #endregion

        #region Properties
        [JsonPropertyName("payload")]
        public ShareAttachmentPayload Payload { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ShareAttachmentRequest)) return false;

            ShareAttachmentRequest sar = (ShareAttachmentRequest) obj;
            return Object.Equals(this.Payload, sar.Payload);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ShareAttachmentRequest{" + base.ToString()
                    + " payload='" + Payload + '\''
                    + '}';
        }
        #endregion
    }
}
