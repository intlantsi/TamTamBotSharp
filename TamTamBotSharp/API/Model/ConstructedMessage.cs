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
    /// Message constructed i in chat
    /// </summary>
    public class ConstructedMessage
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ConstructedMessage()
        {

        }

        public ConstructedMessage(long timestamp, MessageBody body)
        {
            this.Timestamp = timestamp;
            this.Body = body;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Author who sent this message. Can be null if message has been posted on behalf of a channel
        /// </summary>
        [JsonPropertyName("sender")]
        public User Sender { get; init; }
        /// <summary>
        /// Unix-time when message has been created
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; init; }
        /// <summary>
        /// Any linked message: forward or reply
        /// </summary>
        [JsonPropertyName("link")]
        public LinkedMessage Link { get; init; }
        /// <summary>
        /// Body of created message. Text + attachments
        /// </summary>
        [JsonPropertyName("body")]
        public MessageBody Body { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ConstructedMessage)) return false;

            ConstructedMessage cnstrMsg = (ConstructedMessage)obj;
            return Object.Equals(this.Sender, cnstrMsg.Sender) &&
                   Object.Equals(this.Timestamp, cnstrMsg.Timestamp) &&
                   Object.Equals(this.Link, cnstrMsg.Link) &&
                   Object.Equals(this.Body, cnstrMsg.Body);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Sender != null ? Sender.GetHashCode() : 0);
            result = 31 * result + (Timestamp != null ? Timestamp.GetHashCode() : 0);
            result = 31 * result + (Link != null ? Link.GetHashCode() : 0);
            result = 31 * result + (Body != null ? Body.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ConstructedMessage{"
                    + " sender='" + Sender + '\''
                    + " timestamp='" + Timestamp + '\''
                    + " link='" + Link + '\''
                    + " body='" + Body + '\''
                    + '}';
        }
        #endregion
    }
}
