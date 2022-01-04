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
    /// Image attachment
    /// </summary>
    public class PhotoAttachment : Attachment
    {
        #region Fields
        
        #endregion

        #region Constructor
        [JsonConstructor]
        public PhotoAttachment():base()
        {

        }

        public PhotoAttachment(PhotoAttachmentPayload payload) : base()
        {
            this.Payload = payload;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Payload
        /// </summary>
        [JsonPropertyName("payload")]
        public PhotoAttachmentPayload Payload { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is PhotoAttachment)) return false;

            PhotoAttachment par = (PhotoAttachment) obj;
            return Object.Equals(this.Payload, par.Payload);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "PhotoAttachment{" + base.ToString()
                    + " payload='" + Payload + '\''
                    + '}';
        }
        #endregion
    }
}
