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
    /// MediaAttachmentPayload
    /// </summary>
    public class MediaAttachmentPayload: AttachmentPayload
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public MediaAttachmentPayload():base()
        {

        }

        public MediaAttachmentPayload(string token, string url):base(url)
        { 
            this.Token = token;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Use token in case when you are trying to reuse the same attachment in other message
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MediaAttachmentPayload)) return false;

            MediaAttachmentPayload map = (MediaAttachmentPayload) obj;
            return Object.Equals(this.Token, map.Token) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (Token != null ? Token.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MediaAttachmentPayload{" + base.ToString()
                    + " token='" + Token + '\''
                    + '}';
        }
        #endregion
    }
}
