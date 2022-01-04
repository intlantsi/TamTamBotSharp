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
    /// Bot gets this type of update as soon as user pressed Start button
    /// </summary>
    public class BotStartedUpdate:Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public BotStartedUpdate():base()
        {

        }

        public BotStartedUpdate(long chatId, User user, long timestamp):base(timestamp)
        { 
            this.ChatId = chatId;
            this.User = user;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Dialog identifier where event has occurred
        /// </summary>
        [JsonPropertyName("chat_id")]
        public long ChatId { get; init; }
        /// <summary>
        /// User pressed the Start button
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; init; }
        /// <summary>
        /// Additional data from deep-link passed on bot startup
        /// </summary>
        [JsonPropertyName("payload")]
        public string Payload { get; init; }
        /// <summary>
        /// Current user locale in IETF BCP 47 format
        /// </summary>
        [JsonPropertyName("user_locale")]
        public string UserLocale { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            BotStartedUpdate bsu = (BotStartedUpdate) obj;
            return Object.Equals(this.ChatId, bsu.ChatId) &&
                   Object.Equals(this.User, bsu.User) &&
                   Object.Equals(this.Payload, bsu.Payload) &&
                   Object.Equals(this.UserLocale, bsu.UserLocale) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (ChatId != null ? ChatId.GetHashCode() : 0);
            result = 31 * result + (User != null ? User.GetHashCode() : 0);
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            result = 31 * result + (UserLocale != null ? UserLocale.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "BotStartedUpdate{" + base.ToString()
                    + " chatId='" + ChatId + '\''
                    + " user='" + User + '\''
                    + " payload='" + Payload + '\''
                    + " userLocale='" + UserLocale + '\''
                    + '}';
        }
        #endregion
    }
}
