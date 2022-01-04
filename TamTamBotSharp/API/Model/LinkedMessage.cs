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
    /// LinkedMessage
    /// </summary>
    public class LinkedMessage
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public LinkedMessage()
        {

        }

        public LinkedMessage(MessageLinkTypes type, MessageBody message)
        { 
            this.MessageLinkType = type;
            this.Message = message;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Type of linked message
        /// </summary>
        [JsonPropertyName("type")]
        public MessageLinkTypes MessageLinkType { get; init; }
        /// <summary>
        /// Message
        /// </summary>
        [JsonPropertyName("message")]
        public MessageBody Message { get; init; }
        /// <summary>
        /// User sent this message. Can be null if message has been posted on behalf of a channel
        /// </summary>
        [JsonPropertyName("sender")]
        public User Sender { get; init; }
        /// <summary>
        /// Chat where message has been originally posted. For forwarded messages only
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is LinkedMessage)) return false;

            LinkedMessage lm = (LinkedMessage) obj;
            return Object.Equals(this.MessageLinkType, lm.MessageLinkType) &&
                   Object.Equals(this.Sender, lm.Sender) &&
                   Object.Equals(this.ChatId, lm.ChatId) &&
                   Object.Equals(this.Message, lm.Message);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (MessageLinkType != null ? MessageLinkType.GetHashCode() : 0);
            result = 31 * result + (Sender != null ? Sender.GetHashCode() : 0);
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (Message != null ? Message.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "LinkedMessage{"
                    + " type='" + MessageLinkType + '\''
                    + " sender='" + Sender + '\''
                    + " chatId='" + ChatId + '\''
                    + " message='" + Message + '\''
                    + '}';
        }
        #endregion
    }
}



