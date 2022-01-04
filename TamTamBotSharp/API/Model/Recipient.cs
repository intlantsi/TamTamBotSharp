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
    /// New message recipient. Could be user or chat
    /// </summary>
    public class Recipient
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public Recipient()
        {

        }

        public Recipient(long chatId, ChatTypes chatType, long userId) 
        { 
            this.ChatId = chatId;
            this.ChatType = chatType;
            this.UserId = userId;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Chat identifier
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; init; }
        /// <summary>
        /// Chat type
        /// </summary>
        [JsonPropertyName("chat_type")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public ChatTypes ChatType { get; init; }
        /// <summary>
        /// User identifier, if message was sent to user
        /// </summary>
        [JsonPropertyName("user_id")]
        public long UserId { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Recipient)) return false;

            Recipient rcp = (Recipient) obj;
            return Object.Equals(this.ChatId, rcp.ChatId) &&
                   Object.Equals(this.ChatType, rcp.ChatType) &&
                   Object.Equals(this.UserId, rcp.UserId);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (ChatType != null ? ChatType.GetHashCode() : 0);
            result = 31 * result + (UserId != null ? UserId.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Recipient{"
                    + " chatId='" + ChatId + '\''
                    + " chatType='" + ChatType + '\''
                    + " userId='" + UserId + '\''
                    + '}';
        }
        #endregion
    }
}
