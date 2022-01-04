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
    /// You will get this update as soon as message is created
    /// </summary>
    public class MessageCreatedUpdate : Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageCreatedUpdate():base()
        {

        }

        public MessageCreatedUpdate(Message message, long timestamp) : base(timestamp)
        {
            this.CreatedMsg = message;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Newly created message
        /// </summary>
        [JsonPropertyName("message")]
        public Message CreatedMsg { get; init; }
        /// <summary>
        /// Current user locale in IETF BCP 47 format. Available only in dialogs
        /// </summary>
        [JsonPropertyName("user_locale")]
        public string UserLocale { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MessageCreatedUpdate)) return false;

            MessageCreatedUpdate mcu = (MessageCreatedUpdate)obj;
            return Object.Equals(this.CreatedMsg, mcu.CreatedMsg) &&
                   Object.Equals(this.UserLocale, mcu.UserLocale) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (CreatedMsg != null ? CreatedMsg.GetHashCode() : 0);
            result = 31 * result + (UserLocale != null ? UserLocale.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageCreatedUpdate{" + base.ToString()
                    + " message='" + CreatedMsg + '\''
                    + " userLocale='" + UserLocale + '\''
                    + '}';
        }
        #endregion
    }
}