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
    /// PhotoAttachmentPayload
    /// </summary>
    public class PhotoAttachmentPayload
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public PhotoAttachmentPayload()
        {

        }

        public PhotoAttachmentPayload(long photoId, string token, string url) 
        { 
            this.PhotoId = photoId;
            this.Token = token;
            this.URL = url;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Unique identifier of this image
        /// </summary>
        [JsonPropertyName("photo_id")]
        public long PhotoId { get; init; }
        /// <summary>
        /// Token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; init; }
        /// <summary>
        /// Image URL
        /// </summary>
        [JsonPropertyName("url")]
        public string URL { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is PhotoAttachmentPayload)) return false;

            PhotoAttachmentPayload pap = (PhotoAttachmentPayload) obj;
            return Object.Equals(this.PhotoId, pap.PhotoId) &&
                   Object.Equals(this.Token, pap.Token) &&
                   Object.Equals(this.URL, pap.URL);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (PhotoId != null ? PhotoId.GetHashCode() : 0);
            result = 31 * result + (Token != null ? Token.GetHashCode() : 0);
            result = 31 * result + (URL != null ? URL.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "PhotoAttachmentPayload{"
                    + " photoId='" + PhotoId + '\''
                    + " token='" + Token + '\''
                    + " url='" + URL + '\''
                    + '}';
        }
        #endregion
    }
}
