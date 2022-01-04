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
    /// Object sent to bot when user presses button
    /// </summary>
    public class Callback
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public Callback()
        {

        }

        public Callback(long timestamp, string callbackId, User user)
        {
            this.Timestamp = timestamp;
            this.CallbackId = callbackId;
            this.User = user;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Unix-time when user pressed the button
        /// </summary>
        [JsonPropertyName("timestamp")]
        public long Timestamp { get; init; }
        /// <summary>
        /// Current keyboard identifier
        /// </summary>
        [JsonPropertyName("callback_id")]
        public string CallbackId { get; init; }
        /// <summary>
        /// Button payload
        /// </summary>
        [JsonPropertyName("payload")]
        public string Payload { get; init; }
        /// <summary>
        /// User pressed the button
        /// </summary>
        [JsonPropertyName("user")]
        public User User { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is Error)) return false;

            Callback clbck = (Callback)obj;
            return Object.Equals(this.Timestamp, clbck.Timestamp) &&
                Object.Equals(this.CallbackId, clbck.CallbackId) &&
                Object.Equals(this.Payload, clbck.Payload) &&
                Object.Equals(this.User, clbck.User);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (Timestamp != null ? Timestamp.GetHashCode() : 0);
            result = 31 * result + (CallbackId != null ? CallbackId.GetHashCode() : 0);
            result = 31 * result + (Payload != null ? Payload.GetHashCode() : 0);
            result = 31 * result + (User != null ? User.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "Callback{"
            + " timestamp='" + Timestamp + '\''
            + " callbackId='" + CallbackId + '\''
            + " payload='" + Payload + '\''
            + " user='" + User + '\''
            + '}';
        }
        #endregion
    }
}

