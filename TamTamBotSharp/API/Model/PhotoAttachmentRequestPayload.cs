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
    /// Request to attach image. All fields are mutually exclusive
    /// </summary>
    public class PhotoAttachmentRequestPayload
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public PhotoAttachmentRequestPayload()
        {
            Photos = new Dictionary<String, PhotoToken>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Token of any existing attachment
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; init; }
        /// <summary>
        /// Any external image URL you want to attach
        /// </summary>
        [JsonPropertyName("url")]
        public string URL { get; init; }
        /// <summary>
        /// Tokens were obtained after uploading images
        /// </summary>
        [JsonPropertyName("photos")]
        public Dictionary<String, PhotoToken> Photos { get; init; }
        #endregion

        #region Methods

        public PhotoAttachmentRequestPayload PutPhotosItem(string key, PhotoToken photosItem)
        {
            this.Photos.Add(key, photosItem);
            return this;
        }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is PhotoAttachmentRequestPayload)) return false;

            PhotoAttachmentRequestPayload parp = (PhotoAttachmentRequestPayload) obj;
            return Object.Equals(this.URL, parp.URL) &&
                   Object.Equals(this.Token, parp.Token) &&
                   Object.Equals(this.Photos, parp.Photos);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (URL != null ? URL.GetHashCode() : 0);
            result = 31 * result + (Token != null ? Token.GetHashCode() : 0);
            result = 31 * result + (Photos != null ? Photos.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "PhotoAttachmentRequestPayload{"
                    + " url='" + URL + '\''
                    + " token='" + Token + '\''
                    + " photos='" + Photos + '\''
                    + '}';
        }
        #endregion
    }
}
