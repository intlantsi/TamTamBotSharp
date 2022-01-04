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
    /// Bot will get this update when constructed message has been posted to any chat
    /// </summary>
    public class MessageConstructedUpdate:Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageConstructedUpdate():base()
        {

        }

        public MessageConstructedUpdate(string sessionId, ConstructedMessage message, long timestamp):base(timestamp)
        { 
            this.SessionId = sessionId;
            this.UserMsg = message;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Constructor session identifier
        /// </summary>
        [JsonPropertyName("session_id")]
        public string SessionId { get; init; }
        /// <summary>
        /// User message
        /// </summary>
        [JsonPropertyName("message")]
        public ConstructedMessage UserMsg { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            MessageConstructedUpdate mcu = (MessageConstructedUpdate) obj;
            return Object.Equals(this.SessionId, mcu.SessionId) &&
                   Object.Equals(this.UserMsg, mcu.UserMsg) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (SessionId != null ? SessionId.GetHashCode() : 0);
            result = 31 * result + (UserMsg != null ? UserMsg.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageConstructedUpdate{" + base.ToString()
                    + " sessionId='" + SessionId + '\''
                    + " message='" + UserMsg + '\''
                    + '}';
        }
        #endregion
    }
}