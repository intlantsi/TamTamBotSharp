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
    /// You will receive this update when user has been added to chat where bot is administrator
    /// </summary>
    public class UserAddedToChatUpdate : Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public UserAddedToChatUpdate():base()
        {

        }

        public UserAddedToChatUpdate(long chatId, User user, long timestamp) : base(timestamp)
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
        /// <summary>
        /// User who added user to chat. Can be "null" in case when user joined chat by link
        /// </summary>
        [JsonPropertyName("inviter_id")]
        public long InviterId { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is UserAddedToChatUpdate)) return false;

            UserAddedToChatUpdate userAddUpd = (UserAddedToChatUpdate)obj;
            return Object.Equals(this.ChatId, userAddUpd.ChatId) &&
                Object.Equals(this.User, userAddUpd.User) &&
                Object.Equals(this.InviterId, userAddUpd.InviterId) &&
                base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (User != null ? User.GetHashCode() : 0);
            result = 31 * result + (InviterId != null ? InviterId.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "UserAddedToChatUpdate{" + base.ToString()
                    + " chatId='" + ChatId + '\''
                    + " user='" + User + '\''
                    + " inviterId='" + InviterId + '\''
                    + '}';
        }
        #endregion
    }
}
