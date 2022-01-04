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
    /// Send this object when your bot wants to react to when a button is pressed
    /// </summary>
    public class CallbackAnswer
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public CallbackAnswer()
        {

        }
        #endregion

        #region Properties
        /// <summary>
        /// Fill this if you want to modify current message
        /// </summary>
        [JsonPropertyName("message")]
        public long Message { get; init; }
        /// <summary>
        /// Fill this if you just want to send one-time notification to user
        /// </summary>
        [JsonPropertyName("notification")]
        public string Notification { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            CallbackAnswer ca = (CallbackAnswer) obj;
            return Object.Equals(this.Message, ca.Message) &&
                   Object.Equals(this.Notification, ca.Notification);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Message != null ? Message.GetHashCode() : 0);
            result = 31 * result + (Notification != null ? Notification.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "CallbackAnswer{"
                    + " message='" + Message + '\''
                    + " notification='" + Notification + '\''
                    + '}';
        }
        #endregion
    }
}