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
    /// Bot gets this type of update as soon as title has been changed in chat
    /// </summary>
    public class ChatTitleChangedUpdate:Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public ChatTitleChangedUpdate()
        {

        }

        public ChatTitleChangedUpdate(long chatId, User user, string title, long timestamp):base(timestamp)
        { 
            this.ChatId = chatId;
            this.User = user;
            this.Title = title;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Chat identifier where event has occurred
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; init; }
        /// <summary>
        /// User who changed title
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; init; }
        /// <summary>
        /// New title
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is ChatTitleChangedUpdate)) return false;

            ChatTitleChangedUpdate ctChUpd = (ChatTitleChangedUpdate) obj;
            return Object.Equals(this.ChatId, ctChUpd.ChatId) &&
                   Object.Equals(this.User, ctChUpd.User) &&
                   Object.Equals(this.Title, ctChUpd.Title) &&
                    base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (User != null ? User.GetHashCode() : 0);
            result = 31 * result + (Title != null ? Title.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "ChatTitleChangedUpdate{" + base.ToString()
                    + " chatId='" + ChatId + '\''
                    + " user='" + User + '\''
                    + " title='" + Title + '\''
                    + '}';
        }
        #endregion
    }
}