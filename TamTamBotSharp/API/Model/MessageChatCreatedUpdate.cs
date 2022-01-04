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
    /// Bot will get this update when chat has been 
    /// created as soon as first user clicked chat button
    /// </summary>
    public class MessageChatCreatedUpdate:Update
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public MessageChatCreatedUpdate():base()
        {

        }

        public MessageChatCreatedUpdate(Chat chat, string messageId, long timestamp):base(timestamp)
        { 
            this.Ñhat = chat;
            this.MessageId = messageId;
        }

        #endregion

        #region Properties
        /// <summary>
        /// Created chat
        /// </summary>
        [JsonPropertyName("chat")]
        public Chat Ñhat { get; init; }
        /// <summary>
        /// Message identifier where the button has been clicked
        /// </summary>
        [JsonPropertyName("message_id")]
        public string MessageId { get; init; }
        /// <summary>
        /// Payload from chat button
        /// </summary>
        [JsonPropertyName("start_payload")]
        public string StartPayload { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is MessageChatCreatedUpdate)) return false;

            MessageChatCreatedUpdate mccu = (MessageChatCreatedUpdate) obj;
            return Object.Equals(this.Ñhat, mccu.Ñhat) &&
                   Object.Equals(this.MessageId, mccu.MessageId) &&
                   Object.Equals(this.StartPayload, mccu.StartPayload) &&
                   base.Equals(obj);
        }

        public override int GetHashCode()
        {
            int result = base.GetHashCode();
            result = 31 * result + (Ñhat != null ? Ñhat.GetHashCode() : 0);
            result = 31 * result + (MessageId != null ? MessageId.GetHashCode() : 0);
            result = 31 * result + (StartPayload != null ? StartPayload.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "MessageChatCreatedUpdate{" + base.ToString()
                    + " chat='" + Ñhat + '\''
                    + " messageId='" + MessageId + '\''
                    + " startPayload='" + StartPayload + '\''
                    + '}';
        }
        #endregion
    }
}

