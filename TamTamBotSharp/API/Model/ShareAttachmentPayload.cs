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
    /// Payload of ShareAttachmentRequest
    /// </summary>
    public class ShareAttachmentPayload
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ShareAttachmentPayload()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// URL attached to message as media preview
        /// </summary>
        [JsonPropertyName("url")]
        public string URL { get; init; }
        /// <summary>
        /// Attachment token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ShareAttachmentPayload)) return false;

            ShareAttachmentPayload sap = (ShareAttachmentPayload) obj;
            return Object.Equals(this.URL, sap.URL) &&
                   Object.Equals(this.Token, sap.Token);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (URL != null ? URL.GetHashCode() : 0);
            result = 31 * result + (Token != null ? Token.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ShareAttachmentPayload{"
                    + " url='" + URL + '\''
                    + " token='" + Token + '\''
                    + '}';
        }
        #endregion
    }
}
