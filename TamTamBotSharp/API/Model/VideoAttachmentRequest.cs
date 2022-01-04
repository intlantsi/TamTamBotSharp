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
    /// Request to attach video to message
    /// </summary>
    public class VideoAttachmentRequest : AttachmentRequest
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public VideoAttachmentRequest():base()
        {
            AttachmentRequestType = AttachmentRequestTypes.Video;
        }

        public VideoAttachmentRequest(UploadedInfo payload) : base()
        {
            AttachmentRequestType = AttachmentRequestTypes.Video;
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
            if (obj == null || !(obj is VideoAttachmentRequest)) return false;

            VideoAttachmentRequest var = (VideoAttachmentRequest)obj;
            return Object.Equals(this.Payload, var.Payload);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "VideoAttachmentRequest{" + base.ToString()
                    + " payload='" + Payload + '\''
                    + '}';
        }
        #endregion
    }
}
