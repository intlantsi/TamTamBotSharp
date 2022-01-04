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
    /// StickerAttachment
    /// </summary>
    public class StickerAttachment : Attachment
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public StickerAttachment():base()
        {

        }

        public StickerAttachment(StickerAttachmentPayload payload, int width, int height):base()
        { 
            this.Payload = payload;
            this.Width = width;
            this.Height = height;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Payload
        /// </summary>
        [JsonPropertyName("payload")]
        public StickerAttachmentPayload Payload { get; init; }
        /// <summary>
        /// Sticker width
        /// </summary>
        [JsonPropertyName("width")]
        public int Width { get; init; }
        /// <summary>
        /// Sticker height
        /// </summary>
        [JsonPropertyName("height")]
        public int Height { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is StickerAttachment)) return false;

            StickerAttachment stAtt = (StickerAttachment) obj;
            return Object.Equals(this.Payload, stAtt.Payload) &&
                   Object.Equals(this.Width, stAtt.Width) &&
                   Object.Equals(this.Height, stAtt.Height);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            result = 31 * result + (Width != null ? Width.GetHashCode() : 0);
            result = 31 * result + (Height != null ? Height.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "StickerAttachment{" + base.ToString()
                + " payload='" + Payload + '\''
                + " width='" + Width + '\''
                + " height='" + Height + '\''
                + '}';
        }
        #endregion
    }
}
