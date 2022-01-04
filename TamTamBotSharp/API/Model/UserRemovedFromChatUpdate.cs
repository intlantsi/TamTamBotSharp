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
    /// You will receive this update when user has been removed from chat where bot is administrator
    /// </summary>
    public class UserRemovedFromChatUpdate : Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public UserRemovedFromChatUpdate():base()
        {

        }

        public UserRemovedFromChatUpdate(long chatId, User user, long timestamp) : base(timestamp)
        {
            this.ChatId = chatId;
            this.User = user;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Chat identifier where event has occurred
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; init; }
        /// <summary>
        /// User removed from chat
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; init; }
        /// <summary>
        /// Administrator who removed user from chat. Can be null in case when user left chat
        /// </summary>
        [JsonPropertyName("admin_id")]
        public long AdminId { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is UserRemovedFromChatUpdate)) return false;

            UserRemovedFromChatUpdate usrRmvd = (UserRemovedFromChatUpdate) obj;
            return Object.Equals(this.ChatId, usrRmvd.ChatId) &&
                Object.Equals(this.User, usrRmvd.User) &&
                Object.Equals(this.AdminId, usrRmvd.AdminId) &&
                base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (User != null ? User.GetHashCode() : 0);
            result = 31 * result + (AdminId != null ? AdminId.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "UserRemovedFromChatUpdate{" + base.ToString()
                   + " chatId='" + ChatId + '\''
                   + " user='" + User + '\''
                   + " adminId='" + AdminId + '\''
                   + '}';
        }
        #endregion
    }
}
