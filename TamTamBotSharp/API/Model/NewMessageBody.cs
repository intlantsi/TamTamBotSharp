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
    /// NewMessageBody
    /// </summary>
    public class NewMessageBody
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public NewMessageBody()
        {

        }

        public NewMessageBody(string text,List<AttachmentRequest> attachments,NewMessageLink link)
        { 
            this.Text = text;
            this.Attachments = attachments;
            this.Link = link;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Message text
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; init; }
        /// <summary>
        /// Message attachments. See AttachmentRequest and it's inheritors for full information
        /// </summary>
        [JsonPropertyName("attachments")]
        public List<AttachmentRequest> Attachments { get; init; }
        /// <summary>
        /// Link to Message
        /// </summary>
        [JsonPropertyName("link")]
        public NewMessageLink Link { get; init; }
        /// <summary>
        /// If false, chat participants would not be notified
        /// </summary>
        [JsonPropertyName("notify")]
        public bool Notify { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is NewMessageBody)) return false;

            NewMessageBody nmb = (NewMessageBody) obj;
            return Object.Equals(this.Text, nmb.Text) &&
                   Object.Equals(this.Attachments, nmb.Attachments) &&
                   Object.Equals(this.Link, nmb.Link) &&
                   Object.Equals(this.Notify, nmb.Notify);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Text != null ? Text.GetHashCode() : 0);
            result = 31 * result + (Attachments != null ? Attachments.GetHashCode() : 0);
            result = 31 * result + (Link != null ? Link.GetHashCode() : 0);
            result = 31 * result + (Notify != null ? Notify.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "NewMessageBody{"
                    + " text='" + Text + '\''
                    + " attachments='" + Attachments + '\''
                    + " link='" + Link + '\''
                    + " notify='" + Notify + '\''
                    + '}';
        }
        #endregion
    }
}