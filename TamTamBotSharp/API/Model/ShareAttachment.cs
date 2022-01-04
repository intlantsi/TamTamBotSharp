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
    /// ShareAttachment
    /// </summary>
    public class ShareAttachment:Attachment
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ShareAttachment():base()
        {

        }

        public ShareAttachment(ShareAttachmentPayload payload) : base()
        {
            this.Payload = payload;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Payload
        /// </summary>
        [JsonPropertyName("payload")]
        public ShareAttachmentPayload Payload { get; init; }
        /// <summary>
        /// Link preview title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; }
        /// <summary>
        /// Link preview description
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; init; }
        /// <summary>
        /// Link preview image
        /// </summary>
        [JsonPropertyName("image_url")]
        public string ImageUrl { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ShareAttachment)) return false;

            ShareAttachment shAtt = (ShareAttachment) obj;
            return Object.Equals(this.Payload, shAtt.Payload) &&
                   Object.Equals(this.Title, shAtt.Title) &&
                   Object.Equals(this.Description, shAtt.Description) &&
                   Object.Equals(this.ImageUrl, shAtt.ImageUrl);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            result = 31 * result + (Title != null ? Title.GetHashCode() : 0);
            result = 31 * result + (Description != null ? Description.GetHashCode() : 0);
            result = 31 * result + (ImageUrl != null ? ImageUrl.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ShareAttachment{" + base.ToString()
                    + " payload='" + Payload + '\''
                    + " title='" + Title + '\''
                    + " description='" + Description + '\''
                    + " imageUrl='" + ImageUrl + '\''
                    + '}';
        }
        #endregion
    }
}
