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
    /// SendMessageResult
    /// </summary>
    public class SendMessageResult
    {
        #region Fields

        #endregion

        #region Constructor
        [JsonConstructor]
        public SendMessageResult()
        {

        }

        public SendMessageResult(Message message)
        {
            this.SendMessage = message;
        }
        #endregion

        #region Properties
        [JsonPropertyName("message")]
        public Message SendMessage { get; init; }
        #endregion

        #region Object override
        public override bool Equals(object obj)
        {
            if (this == obj) return true;
            if (obj == null || !(obj is SendMessageResult)) return false;

            SendMessageResult smr = (SendMessageResult)obj;
            return Object.Equals(this.SendMessage, smr.SendMessage);
        }

        public override int GetHashCode()
        {
            int result = 1;
            result = 31 * result + (SendMessage != null ? SendMessage.GetHashCode() : 0);
            return result;
        }

        public override string ToString()
        {
            return "SendMessageResult{"
                    + " message='" + SendMessage + '\''
                    + '}';
        }
        #endregion
    }
}