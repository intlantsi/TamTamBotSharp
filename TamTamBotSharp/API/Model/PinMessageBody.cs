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
    /// PinMessageBody
    /// </summary>
    public class PinMessageBody
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public PinMessageBody()
        {

        }

        public PinMessageBody(string messageId)
        {
            this.MessageId = messageId;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Identifier of message to be pinned in chat
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }
        /// <summary>
        /// If true, participants will be notified with system message in chat/channel
        /// </summary>
        [JsonPropertyName("notify")]
        public bool Notify { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is PinMessageBody)) return false;

            PinMessageBody pmb = (PinMessageBody)obj;
            return Object.Equals(this.MessageId, pmb.MessageId) &&
                Object.Equals(this.Notify, pmb.Notify);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (MessageId != null ? MessageId.GetHashCode() : 0);
            result = 31 * result + (Notify != null ? Notify.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "PinMessageBody{"
                   + " messageId='" + MessageId + '\''
                   + " notify='" + Notify + '\''
                   + '}';
        }
        #endregion
    }
}

