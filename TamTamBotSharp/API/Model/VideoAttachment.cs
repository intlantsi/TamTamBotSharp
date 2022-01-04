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
    /// VideoAttachment
    /// </summary>
    public class VideoAttachment:Attachment
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public VideoAttachment():base()
        {

        }

        public VideoAttachment(MediaAttachmentPayload payload) : base()
        {
            this.Payload = payload;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Payload
        /// </summary>
        [JsonPropertyName("payload")]
        public MediaAttachmentPayload Payload { get; init; }
        /// <summary>
        /// Video thumbnail
        /// </summary>
        [JsonPropertyName("thumbnail")]
        public PhotoAttachmentPayload Thumbnail { get; init; }
        /// <summary>
        /// Video width
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; init; }
        /// <summary>
        /// Video height
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; init; }
        /// <summary>
        /// Video duration in seconds
        /// </summary>
        [JsonPropertyName("duration")]
        public int Duration { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is VideoAttachment)) return false;

            VideoAttachment va = (VideoAttachment) obj;
            return Object.Equals(this.Payload, va.Payload) &&
                   Object.Equals(this.Thumbnail, va.Thumbnail) &&
                   Object.Equals(this.Width, va.Width) &&
                   Object.Equals(this.Height, va.Height) &&
                   Object.Equals(this.Duration, va.Duration);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            result = 31 * result + (Thumbnail != null ? Thumbnail.GetHashCode() : 0);
            result = 31 * result + (Width != null ? Width.GetHashCode() : 0);
            result = 31 * result + (Height != null ? Height.GetHashCode() : 0);
            result = 31 * result + (Duration != null ? Duration.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "VideoAttachment{" + base.ToString()
                    + " payload='" + Payload + '\''
                    + " thumbnail='" + Thumbnail + '\''
                    + " width='" + Width + '\''
                    + " height='" + Height + '\''
                    + " duration='" + Duration + '\''
                    + '}';
        }
        #endregion
    }
}
