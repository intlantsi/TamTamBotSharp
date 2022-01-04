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
    /// Message in chat
    /// </summary>
    public class Message
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public Message()
        {

        }

        public Message(Recipient recipient, long timestamp, MessageBody body) 
        { 
            this.Recipient = recipient;
            this.Timestamp = timestamp;
            this.Body = body;
        }
        #endregion

        #region Properties
        /// <summary>
        /// User who sent this message. Can be null if message has been posted on behalf of a channel
        /// </summary>
        [JsonPropertyName("sender")]
        public User Sender { get; init; }
        /// <summary>
        /// Message recipient. Could be user or chat
        /// </summary>
        [JsonPropertyName("recipient")]
        public Recipient Recipient { get; init; }
        /// <summary>
        /// Unix-time when message was created
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; init; }
        /// <summary>
        /// Forwarded or replied message
        /// </summary>
        [JsonPropertyName("link")]
        public LinkedMessage Link { get; init; }
        /// <summary>
        /// Body of created message. Text + attachments. Could be null if message contains only forwarded message
        /// </summary>
        [JsonPropertyName("body")]
        public MessageBody Body { get; init; }
        /// <summary>
        /// Message statistics. Available only for channels in [GET:/messages](#operation/getMessages) context
        /// </summary>
        [JsonPropertyName("stat")]
        public MessageStat Stat { get; init; }
        /// <summary>
        /// Message public URL. Can be null for dialogs or non-public chats/channels
        /// </summary>
        [JsonPropertyName("url")]
        public bool URL { get; init; }
        /// <summary>
        /// Bot-constructor created this message
        /// </summary>
        [JsonPropertyName("constructor")]
        public bool Constructor { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Message)) return false;

            Message msg = (Message) obj;
            return Object.Equals(this.Sender, msg.Sender) &&
                   Object.Equals(this.Recipient, msg.Recipient) &&
                   Object.Equals(this.Timestamp, msg.Timestamp) &&
                   Object.Equals(this.Link, msg.Link) &&
                   Object.Equals(this.Body, msg.Body) &&
                   Object.Equals(this.Stat, msg.Stat) &&
                   Object.Equals(this.URL, msg.URL) &&
                   Object.Equals(this.Constructor, msg.Constructor);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Sender != null ? Sender.GetHashCode() : 0);
            result = 31 * result + (Recipient != null ? Recipient.GetHashCode() : 0);
            result = 31 * result + (Timestamp != null ? Timestamp.GetHashCode() : 0);
            result = 31 * result + (Link != null ? Link.GetHashCode() : 0);
            result = 31 * result + (Body != null ? Body.GetHashCode() : 0);
            result = 31 * result + (Stat != null ? Stat.GetHashCode() : 0);
            result = 31 * result + (URL != null ? URL.GetHashCode() : 0);
            result = 31 * result + (Constructor != null ? Constructor.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Message{"
                    + " sender='" + Sender + '\''
                    + " recipient='" + Recipient + '\''
                    + " timestamp='" + Timestamp + '\''
                    + " link='" + Link + '\''
                    + " body='" + Body + '\''
                    + " stat='" + Stat + '\''
                    + " url='" + URL + '\''
                    + " constructor='" + Constructor + '\''
                    + '}';
        }
        #endregion
    }
}
