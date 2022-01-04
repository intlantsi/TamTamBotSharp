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
    /// You will receive this update when bot has been removed from chat
    /// </summary>
    public class BotRemovedFromChatUpdate : Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public BotRemovedFromChatUpdate():base()
        {

        }

        public BotRemovedFromChatUpdate(long chatId, User user, long timestamp) : base(timestamp)
        {
            this.ChatId = chatId;
            this.User = user;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Chat id where bot was added
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; init; }
        /// <summary>
        /// User who added bot to chat
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            BotRemovedFromChatUpdate botRmvd = (BotRemovedFromChatUpdate)obj;
            return Object.Equals(this.ChatId, botRmvd.ChatId) &&
                    Object.Equals(this.User, botRmvd.User) &&
                    base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (User != null ? User.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "BotRemovedFromChatUpdate{" + base.ToString()
                    + " chatId='" + ChatId + '\''
                    + " user='" + User + '\''
                    + '}';
        }
        #endregion
    }
}
