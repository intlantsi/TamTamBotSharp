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
    /// You will get this Update as soon as message is removed
    /// </summary>
    public class MessageRemovedUpdate:Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageRemovedUpdate():base()
        {

        }

        public MessageRemovedUpdate(string messageId, long chatId, long userId, long timestamp) : base(timestamp)
        {
            this.MessageId = messageId;
            this.ChatId = chatId;
            this.UserId = userId;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Identifier of removed message
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }
        /// <summary>
        /// Chat identifier where message has been deleted
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; init; }
        /// <summary>
        /// User who deleted this message
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MessageRemovedUpdate)) return false;

            MessageRemovedUpdate mru = (MessageRemovedUpdate) obj;
            return Object.Equals(this.MessageId, mru.MessageId) &&
                   Object.Equals(this.ChatId, mru.ChatId) &&
                   Object.Equals(this.UserId, mru.UserId) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (MessageId != null ? MessageId.GetHashCode() : 0);
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (UserId != null ? UserId.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageRemovedUpdate{" + base.ToString()
                    + " messageId='" + MessageId + '\''
                    + " chatId='" + ChatId + '\''
                    + " userId='" + UserId + '\''
                    + '}';
        }
        #endregion
    }
}
