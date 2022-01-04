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
    /// Schema representing body of message
    /// </summary>
    public class MessageBody
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageBody()
        {

        }

        public MessageBody(string mid, long seq, string text, List<Attachment> attachments)
        { 
            this.Mid = mid;
            this.Seq = seq;
            this.Text = text;
            this.Attachments = attachments;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Unique identifier of message
        /// </summary>
        [JsonPropertyName("mid")]
        public string Mid { get; init; }
        /// <summary>
        /// Sequence identifier of message in chat
        /// </summary>
        [JsonPropertyName("seq")]
        public long Seq { get; init; }
        /// <summary>
        /// Message text
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; init; }
        /// <summary>
        /// Message attachments.Could be one of Attachment type. See description of this schema
        /// </summary>
        [JsonPropertyName("attachments")]
        public List<Attachment> Attachments { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MessageBody)) return false;

            MessageBody mb = (MessageBody) obj;
            return Object.Equals(this.Mid, mb.Mid) &&
                   Object.Equals(this.Seq, mb.Seq) &&
                   Object.Equals(this.Text, mb.Text) &&
                   Object.Equals(this.Attachments, mb.Attachments);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Mid != null ? Mid.GetHashCode() : 0);
            result = 31 * result + (Seq != null ? Seq.GetHashCode() : 0);
            result = 31 * result + (Text != null ? Text.GetHashCode() : 0);
            result = 31 * result + (Attachments != null ? Attachments.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageBody{"
                    + " mid='" + Mid + '\''
                    + " seq='" + Seq + '\''
                    + " text='" + Text + '\''
                    + " attachments='" + Attachments + '\''
                    + '}';
        }
        #endregion
    }
}
